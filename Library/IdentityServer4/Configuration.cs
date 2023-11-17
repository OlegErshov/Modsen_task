using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("LibraryWebApi", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("LibraryWebApi", "Web API", new [] {JwtClaimTypes.Name})
                {
                    Scopes = { "LibraryWebApi" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "library-web-api",
                    ClientName = "Library Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://localhost:7059/swagger/oauth2-redirect.html"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:7059"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://.../signin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "LibraryWebApi"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
