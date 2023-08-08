using System.Drawing;

namespace Portfolio.MechanistTower.Configurations
{
    public class ConfigurationSigils : IConfigurationSigils
    {
        public string AdminName { get; set; }

        public string AdminPass { get; set; }

        public string AdminEmail { get; set; }

        public string CosmosEndpoint { get; set; }

        public string CosmosKey { get; set; }

        public string AzureStorageConnectionString { get; set; }
    }
}