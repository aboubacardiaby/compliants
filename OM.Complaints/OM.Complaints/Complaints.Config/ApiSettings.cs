namespace Complaints.Config
{
    public class ApiSettings
    {
        public string AzureTenantId { get; set; }
        public string ApplicationId { get; set; }
        public string AppSecret { get; set; }
        public string AccessToken { get; set; }
        public string AuthorityUrlFormat { get; set; } // {tenantid}
        public string ScopeUrlFormat { get; set; } // {graphAPIScope}

        public string GraphAPIScope { get; set; }

        public string TempDirectoryPath { get; set; }
        public string ErrorMessageRecipients { get; set; }
        public string InboundFolderName { get; set; }
        public string ArchiveFolder { get; set; }
        public string ErrorFolder { get; set; }

        public string Environment { get; set; }

        public string AzureWebJobsStorage { get; set; }
        public string ContainerName { get; set; }
        public string ReadyContainerName { get; set; }

        public string ContractManagerServiceUrl { get; set; }

    }
}