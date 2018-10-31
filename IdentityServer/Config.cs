using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //other clients omitted

                ////////////////////////////////////////////
                //* OpenID Connect implicit flow client (MVC) *//
                ////////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "Mvc Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    // where to redirect to after login
                    RedirectUris = {
                        "http://localhost:60646/signin-oidc",
                        "http://localhost:50646/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:60646/signout-callback-oidc",
                        "http://localhost:50646/signout-callback-oidc"

                    },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }

                ////////////////////////////////////////////
                //* resource owner password client grant *//
                ////////////////////////////////////////////
                //new Client
                //{
                //    ClientId = "ro.client",

                //    // no interactive user, use the clientid/secret for authentication
                //    //AllowedGrantTypes = GrantTypes.ClientCredentials

                //    //username password, use a different grant type
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                //    // secret for authentication
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    // scopes that client has access to
                //    AllowedScopes = { "api1" }
                //}
            };
        }
    }
}
