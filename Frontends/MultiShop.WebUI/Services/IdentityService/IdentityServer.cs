
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.IdentityServer
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ClientSettings> clientSettings,
            IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }


        public async Task<bool> GetRefreshToken()
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(
                new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = false
                    }
                });


            var refreshToken = await _httpContextAccessor.HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);


            RefreshTokenRequest refreshTokenRequest = new()
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                RefreshToken = refreshToken,
                Address = discoveryEndPoint.TokenEndpoint
            };


            var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);


            var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            };


            var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();

            var properties = result.Properties;

            properties.StoreTokens(authenticationToken);


            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                result.Principal,
                properties);


            return true;
        }



        public async Task<bool> SignIn(SignInDto signInDto)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(
                new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = false
                    }
                });


            if (discoveryEndPoint.IsError)
            {
                throw new Exception(discoveryEndPoint.Error);
            }



            string clientId = _clientSettings.MultiShopManagerClient.ClientId;
            string clientSecret = _clientSettings.MultiShopManagerClient.ClientSecret;

            if (signInDto.Password.ToLower() == "Admin123!")
            {
                clientId = _clientSettings.MultiShopAdminClient.ClientId;
                clientSecret = _clientSettings.MultiShopAdminClient.ClientSecret;
            }

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                UserName = signInDto.Username,
                Password = signInDto.Password,
                Address = discoveryEndPoint.TokenEndpoint,
                Scope = "openid profile email offline_access CatalogReadPermission CatalogFullPermission BasketFullPermission OrderFullPermission"
            };



            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);


            if (token.IsError)
            {
                throw new Exception(token.Error);
            }



            // Read JWT claims
            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token.AccessToken);

            var claims = jwtToken.Claims.ToList();



            // ================================
            // Add sub claim for Basket service
            // ================================

            if (!claims.Any(x => x.Type == "sub"))
            {
                var userIdClaim =
                    claims.FirstOrDefault(x => x.Type == "nameidentifier")
                    ??
                    claims.FirstOrDefault(x => x.Type == "email");


                if (userIdClaim != null)
                {
                    claims.Add(new Claim(
                        "sub",
                        userIdClaim.Value
                    ));
                }
                else
                {
                    // last fallback
                    claims.Add(new Claim(
                        "sub",
                        signInDto.Username
                    ));
                }
            }



            // ================================
            // Fix antiforgery Name problem
            // ================================

            if (!claims.Any(x => x.Type == "name"))
            {
                var subClaim = claims.FirstOrDefault(x => x.Type == "sub");

                if (subClaim != null)
                {
                    claims.Add(new Claim(
                        "name",
                        subClaim.Value
                    ));
                }
            }



            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                "name",
                "role"
            );


            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);



            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = false
            };



            authenticationProperties.StoreTokens(new List<AuthenticationToken>
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now
                        .AddSeconds(token.ExpiresIn)
                        .ToString()
                }
            });



            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authenticationProperties);



            return true;
        }
    }
}