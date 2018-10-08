using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcIdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("BlogAPI", "Blog API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequireConsent = true,
                    ClientSecrets =
                    {
                        new Secret("mysecret".Sha256())
                    },
                    RedirectUris = { "http://localhost:7002/signin-hex"},
                    PostLogoutRedirectUris = {"http://localhost:7002/signout-hex"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "BlogAPI"
                    },
                    AllowOfflineAccess = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "rakesh",
                    Password = "password",
                    Claims = new[]
                    {
                        new Claim("name", "rakesh"),
                        new Claim("website", "http://localhost:7778")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "thakur",
                    Password = "password",
                    Claims = new[]
                    {
                        new Claim("name", "thakur"),
                        new Claim("website", "http://localhost:7778")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
