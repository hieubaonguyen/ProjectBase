using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("weather.get", "Get API"),
                new ApiScope("weather.create", "Create API"),
                new ApiScope("weather.update", "Update API"),
                new ApiScope("weather.delete", "Delete API"),

                new ApiScope("customer.get", "Get API"),
                new ApiScope("customer.create", "Create API"),
                new ApiScope("customer.update", "Update API"),
                new ApiScope("customer.delete", "Delete API"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "weather",
                    Scopes =
                    {
                        "weather.get",
                        "weather.create",
                        "weather.update",
                        "weather.delete"
                    }
                },
                new ApiResource
                {
                    Name = "customer",
                    Scopes =
                    {
                        "customer.get",
                        "customer.create",
                        "customer.update",
                        "customer.delete"
                    }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "customer.update" }
                },
                new Client
                {
                    ClientId = "web",

                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "customer.get"
                    },

                    AllowOfflineAccess = true
                }
            };
    }
}
