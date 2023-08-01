namespace Portfolio.MechanistTower.Configurations
{
    public static class ConfigurationRitual
    {
        public static ConfigurationSigils Invoke(IConfiguration configuration)
        {
            // TODO: Replace with config binding
            var configurationSigils = new ConfigurationSigils()
            {
                AdminName = configuration["SuperAdmin:UserName"],
                AdminPass = configuration["SuperAdmin:Password"],
                AdminEmail = configuration["SuperAdmin:Email"],
                CosmosEndpoint = configuration["Cosmos:Endpoint"],
                CosmosKey = configuration["Cosmos:Key"]
            };

            return configurationSigils;
        }
    }
}