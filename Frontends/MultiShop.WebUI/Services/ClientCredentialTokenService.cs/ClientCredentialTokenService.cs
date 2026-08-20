
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete
{
    using IdentityModel.Client;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;


    namespace MultiShop.WebUI.Services.Concrete
    {
        public class ClientCredentialTokenService : IClientCredentialTokenService
        {
            private readonly ServiceApiSettings _serviceApiSettings;
            private readonly HttpClient _httpClient;
            private readonly IMemoryCache _memoryCache;
            private readonly ClientSettings _clientSettings;

            public ClientCredentialTokenService(
                IOptions<ServiceApiSettings> serviceApiSettings,
                HttpClient httpClient,
                IMemoryCache memoryCache,
                IOptions<ClientSettings> clientSettings)
            {
                _serviceApiSettings = serviceApiSettings.Value;
                _httpClient = httpClient;
                _memoryCache = memoryCache;
                _clientSettings = clientSettings.Value;
            }

            public async Task<string> GetToken()
            {
                if (_memoryCache.TryGetValue("multishoptoken", out string accessToken))
                {
                    return accessToken;
                }

                var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
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

                var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
                {
                    ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                    ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                    Address = discoveryEndPoint.TokenEndpoint
                };

                var token = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

                if (token.IsError)
                {
                    throw new Exception(token.Error);
                }

                _memoryCache.Set(
                    "multishoptoken",
                    token.AccessToken,
                    TimeSpan.FromSeconds(token.ExpiresIn));

                return token.AccessToken;
            }
        }
    }
}