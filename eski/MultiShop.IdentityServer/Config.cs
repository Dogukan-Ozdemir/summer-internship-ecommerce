// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        // Identity Resources
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        // API Resources
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ResourceCatalogApi", "Catalog API")
                {
                    Scopes =
                    {
                        new Scope("CatalogReadPermission"),
                        new Scope("CatalogFullPermission")
                    }
                },

                new ApiResource("ResourceDiscountApi", "Discount API")
                {
                    Scopes =
                    {
                        new Scope("DiscountFullPermission")
                    }
                },

                new ApiResource("ResourceOrderApi", "Order API")
                {
                    Scopes =
                    {
                        new Scope("OrderFullPermission")
                    }
                }
            };
        }

        // Clients
        public static IEnumerable<Client> GetClients(IConfigurationSection stsConfig)
        {
            return new List<Client>
            {
                new Client // visitor
                {
                    ClientId = "MultiShopVisitorId",
                    ClientName = "MultiShop Visitor",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("multishopsecret".Sha256())
                    },

                    AllowedScopes =
                    {
                        "openid",
                        "profile",
                        "email",

                        "CatalogReadPermission",
                        

                        
                    },

                    AccessTokenLifetime = 36000
                },
                new Client  //manager
                {
                    ClientId = "MultiShopManagerId",
                    ClientName = "MultiShop Manager",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("multishopsecret".Sha256())
                    },
                     AllowedScopes ={ "CatalogReadPermission", "CatalogFullPermission" }
                },
                new Client //admin
                {
                    ClientId = "MultiShopAdminId",
                    ClientName = "MultiShop Admin",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("multishopsecret".Sha256())
                    },
                    AllowedScopes ={ "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                    AccessTokenLifetime =600
                },
                



            };
        }
    }
}