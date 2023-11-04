using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaints.Config
{
    public class ApiSettingsHelper
    {
        public readonly ApiSettings Settings;

        public ApiSettingsHelper(ApiSettings settings)
        {
            Settings = settings;
        }


        public string GetScopeUrl()
        {
            return Settings.ScopeUrlFormat
                    .Replace("{graphAPIScope}", Settings.GraphAPIScope);
        }

        public string GetAuthorityUrl()
        {
            return Settings.AuthorityUrlFormat
                    .Replace("{tenantId}", Settings.AzureTenantId);
        }

        public async Task<string> GetAccessToken()
        {

            // new MSAL     example:  https://login.microsoftonline.com/e18c199f-7bc4-489e-b810-eddee385899b/oauth2/v2.0/token
            var authUrl = GetAuthorityUrl();
            var clientApp = ConfidentialClientApplicationBuilder.Create(Settings.ApplicationId)
                .WithClientSecret(Settings.AppSecret)
                .WithAuthority(authUrl)
                .Build();

            var scope = GetScopeUrl();
            var authenticationResult = await clientApp.AcquireTokenForClient(new[] { scope }).ExecuteAsync().ConfigureAwait(false);

            //var header = authenticationResult.CreateAuthorizationHeader();

            return authenticationResult.AccessToken;

        }
        }
    }
