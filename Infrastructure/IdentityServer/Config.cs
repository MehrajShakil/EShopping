// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalogApi"),
                new ApiScope("basketApi"),
                new ApiScope("eshoppinggateway")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                // List of Microservices can go here.

                // Here, Api resource name is the audience.
                new ApiResource("Catalog", "Catalog.Api")
                {
                    Scopes = ["catalogApi"]
                },
                new ApiResource("Basket", "Basket.Api")
                {
                    Scopes = ["basketApi"]
                },
                new ApiResource("EshoppingGateway", "Eshopping Gateway")
                {
                    Scopes = ["eshoppinggateway"]
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "catalog",
                    ClientName = "Catalog.Api",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "catalogApi" }
                },

                new Client
                {
                    ClientId = "basket",
                    ClientName = "Basket.Api",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "basketApi" }
                },

                new Client
                {
                    ClientId = "eshoppinggatewayclient",
                    ClientName = "Eshopping Gateway Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "eshoppinggateway" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                },
            };
    }
}
