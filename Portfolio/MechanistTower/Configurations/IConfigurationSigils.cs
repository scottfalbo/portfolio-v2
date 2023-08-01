namespace Portfolio.MechanistTower.Configurations
{
    public interface IConfigurationSigils
    {
        public string AdminName { get; set; }

        public string AdminPass { get; set; }

        public string AdminEmail { get; set; }

        public string CosmosEndpoint { get; set; }

        public string CosmosKey { get; set; }
    }
}