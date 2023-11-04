using AutoMapper;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using OM.Complaints.Models;
using System.Text.Json;
using NLog;
//using OM.Shared;
using Azure.Identity;
using Complaints.Config;
using System.Security.Principal;
using NLog.Fluent;
using OM.Complaints.Services;

namespace OM.Complaints.Builders
{
    public class ComplaintViewModelBuilder: IComplaintViewModelBuilder
    {
        private readonly IMailService _mailService;
        public string CurrentUser { get; set; }
        //public Microsoft.Extensions.Logging.ILogger logger;
        public ApiSettings settings;

        public ComplaintViewModelBuilder(IMailService _MailService)
        {
            //logger = new Logger(ILogger);
            _mailService = _MailService;

            CurrentUser = "";

            settings = new ApiSettings();
        }

        public Complaint GetComplaintData()
        {
            var model = new Complaint()
            {
            };
            return model;
        }

        public NotificationResponseVM SendComplaintNotification(Complaint complaintData)
        {
            //var authToken = InitializeConfigSettings();
            var result =  new NotificationResponseVM();

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson = JsonSerializer.Serialize<Complaint>(complaintData, opt);

            //var scopes = new[] { "https://graph.microsoft.com/.default" };

            //// Multi-tenant apps can use "common",
            //// single-tenant apps must use the tenant ID from the Azure portal
            //var tenantId = "e18c199f-7bc4-489e-b810-eddee385899b";

            //// Value from app registration
            //var clientId = "249f2d7d-dace-4e12-9d27-caf9c0208e03";
            //var clientSecret = "8f1b1324-00b9-43c9-ade6-c4669d271d38";

            //// For authorization code flow, the user signs into the Microsoft
            //// identity platform, and the browser is redirected back to your app
            //// with an authorization code in the query parameters
            //var authorizationCode = "AUTH_CODE_FROM_REDIRECT";

            //// using Azure.Identity;
            //var options = new AuthorizationCodeCredentialOptions
            //{
            //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            //};

            //// https://learn.microsoft.com/dotnet/api/azure.identity.authorizationcodecredential
            //var authCodeCredential = new AuthorizationCodeCredential(
            //    tenantId, clientId, clientSecret, authorizationCode, options);

            //GraphServiceClient client = new GraphServiceClient(authCodeCredential, scopes);

            try
            {
                var mailData = new MailData
                {
                    EmailBody = strJson,
                    EmailSubject = "New Complaint submitted",
                    EmailToName = "John Walker",
                    EmailToId = "John.Walker@owens-minor.com"
                };

                result.Success = _mailService.SendMail(mailData);
            }
            catch (Exception err)
            {
                result.Success = false;
                result.Errors.Add(err.Message);

                //Logger.LogError(err, "There was a problem sending the error email: {0}", err.Message);
            }
            return result;
        }

        private string InitializeConfigSettings()
        {
            //connectionInfo = new DatabaseConnectionInfo();
            //connectionInfo.Server = GetConfigSetting("DBServer");
            //connectionInfo.Database = GetConfigSetting("DBDatabase");
            //connectionInfo.UserName = GetConfigSetting("DBUser");
            //connectionInfo.Password = GetConfigSetting("DBUserPass");
            //connectionInfo.IntegratedAuth = bool.Parse(GetConfigSetting("IntegratedAuth"));

            //DatabaseHelper.DBTest(connectionInfo);

            settings = new ApiSettings()
            {
                GraphAPIScope = GetConfigSetting("GraphAPIScope"),
                AzureTenantId = GetConfigSetting("AzureTenantId"),
                ApplicationId = GetConfigSetting("ApplicationId"),
                AppSecret = GetConfigSetting("AppSecret"),
                ScopeUrlFormat = GetConfigSetting("ScopeUrlFormat"),
                AuthorityUrlFormat = GetConfigSetting("AuthorityUrlFormat"),
                TempDirectoryPath = GetConfigSetting("TempDirectoryPath"),
                ErrorMessageRecipients = GetConfigSetting("ErrorMessageRecipients"),
                InboundFolderName = GetConfigSetting("InboundFolderName"),
                ArchiveFolder = GetConfigSetting("ArchiveFolder"),
                ErrorFolder = GetConfigSetting("ErrorFolder"),
                Environment = GetConfigSetting("Environment"),
                AzureWebJobsStorage = GetConfigSetting("AzureWebJobsStorage"),
                ContainerName = GetConfigSetting("ContainerName"),
                ReadyContainerName = GetConfigSetting("ReadyContainerName"),
                ContractManagerServiceUrl = GetConfigSetting("ContractManagerServiceUrl")
            };

            var _settingsMgr = new ApiSettingsHelper(settings);
            var token = _settingsMgr.GetAccessToken().Result;

            Console.WriteLine("End intialize config settings...");

            return token;
        }


        private string GetConfigSetting(string key)
        {
            var value = System.Configuration.ConfigurationManager.AppSettings[key]; // get from local.settings.json

            if (string.IsNullOrEmpty(value))  // get from environment if running from server
                value = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
            return value;
        }
    }
}
