// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MultiShopIdentityServer;

public class Config
{
    /*   public static IEnumerable<IdentityResource> GetIdentityResources()
       {
           return new List<IdentityResource>
           {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
               new IdentityResources.Email()
           };
       }

       public static IEnumerable<ApiScope> GetApiScopes()
       {
           return new List<ApiScope>
           {
               //new ApiScope("dataEventRecords", "Scope for the dataEventRecords ApiResource"),
               //new ApiScope("securedFiles",  "Scope for the securedFiles ApiResource")
           };
       }

       public static IEnumerable<ApiResource> GetApiResources()
       {
           return new List<ApiResource>
           {
               //new ApiResource("dataEventRecordsApi")
               //{
               //    ApiSecrets =
               //    {
               //        new Secret("dataEventRecordsSecret".Sha256())
               //    },
               //    Scopes = new List<string> { "dataEventRecords" }
               //},
               //new ApiResource("securedFilesApi")
               //{
               //    ApiSecrets =
               //    {
               //        new Secret("securedFilesSecret".Sha256())
               //    },
               //    Scopes = new List<string> { "securedFiles" }
               //}
           };
       }

       public static IEnumerable<Client> GetClients(IConfigurationSection stsConfig)
       {
           // TODO use configs in app
           //var yourConfig = stsConfig["ClientUrl"];

           return new List<Client>
           {
               // example code
               //new Client
               //{
               //    ClientName = "angularclient",
               //    ClientId = "angularclient",
               //    AccessTokenType = AccessTokenType.Reference,
               //    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
               //    IdentityTokenLifetime = 30,
               //    AllowedGrantTypes = GrantTypes.Implicit,
               //    AllowAccessTokensViaBrowser = true,
               //    RedirectUris = new List<string>
               //    {
               //        "https://localhost:44311",
               //        "https://localhost:44311/silent-renew.html"

               //    },
               //    PostLogoutRedirectUris = new List<string>
               //    {
               //        "https://localhost:44311/unauthorized",
               //        "https://localhost:44311"
               //    },
               //    AllowedCorsOrigins = new List<string>
               //    {
               //        "https://localhost:44311",
               //        "http://localhost:44311"
               //    },
               //    AllowedScopes = new List<string>
               //    {
               //        "openid",
               //        "role",
               //        "profile",
               //        "email"
               //    }
               //}
           };
       } */

    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
 {
    new ApiResource("ResourceCatalog")
    {
        Scopes =
        {
            "CatalogFullPermission",
            "CatalogReadPermission"
        },

        UserClaims =
        {
            "name",
            "email",
            "role"
        }
    },

    new ApiResource("ResourceDiscount")
    {
        Scopes =
        {
            "DiscountFullPermission"
        },

        UserClaims =
        {
            "name",
            "email",
            "role"
        }
    },

    new ApiResource("ResourceOrder")
    {
        Scopes =
        {
            "OrderFullPermission"
        },

        UserClaims =
        {
            "name",
            "email",
            "role"
        }
    },

    new ApiResource("ResourceCargo")
    {
        Scopes =
        {
            "CargoFullPermission"
        },

        UserClaims =
        {
            "name",
            "email",
            "role"
        }
    },

    new ApiResource("ResourceBasket")
    {
        Scopes =
        {
            "BasketFullPermission"
        },

        UserClaims =
        {
            "name",
            "email",
            "role"
        }
    },

    new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
 };

    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[] {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiScope> APiScopes => new ApiScope[] {
        new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
        new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
        new ApiScope("DiscountFullPermission","Full authority for discount operations"),
        new ApiScope("OrderFullPermission","Full authority for order operations"),
        new ApiScope("CargoFullPermission","Full authority for Cargo operations"),
        new ApiScope("BasketFullPermission","Full authority for basket operations"),
        new ApiScope (IdentityServerConstants.LocalApi.ScopeName)
    };

    public static IEnumerable<Client> Clients => new Client[]
{
    new Client //visitor
    {
        ClientName = "MultiShop Visitor User",
        ClientId = "MultiShopVisitorId",
        ClientSecrets =
        {
            new Secret("multishopsecret".Sha256())
        },
        AllowedGrantTypes = GrantTypes.ClientCredentials,
        AllowedScopes =
        {
            "CargoFullPermission",
            "DiscountFullPermission",
            "CatalogReadPermission",
            IdentityServerConstants.LocalApi.ScopeName,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile
        }
    },

    new Client // manager
    {
        ClientName = "MultiShop Manager User",
        ClientId = "MultiShopManagerId",

        ClientSecrets =
        {
            new Secret("multishopsecret".Sha256())
        },

        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

        AllowOfflineAccess = true,

        AllowedScopes =
        {
            "CargoFullPermission",
            "CatalogReadPermission",
            "CatalogFullPermission",
            "BasketFullPermission",
            "OrderFullPermission",
            "BasketFullPermission",
            "DiscountFullPermission",
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OfflineAccess
        }
    },

    new Client //admin
    {
        ClientName = "MultiShop Admin User",
        ClientId = "MultiShopAdminId",
        ClientSecrets =
        {
            new Secret("multishopsecret".Sha256())
        },
        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
        AllowedScopes =
        {
            "CatalogReadPermission",
            "CatalogFullPermission",
            "DiscountFullPermission",
            "OrderFullPermission",
            "CargoFullPermission",
            "BasketFullPermission",
            IdentityServerConstants.LocalApi.ScopeName,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile
        },
        AccessTokenLifetime=600
    }
};


}