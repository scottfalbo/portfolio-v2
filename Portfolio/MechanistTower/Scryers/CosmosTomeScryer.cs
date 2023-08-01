using Microsoft.Azure.Cosmos;

namespace Portfolio.MechanistTower.Scryers
{
    public class CosmosTomeScryer : ICosmosTomeScryer
    {
        private readonly CosmosClient _cosmosClient;

        public CosmosClient ConjureScryer() => _cosmosClient;

        public CosmosTomeScryer(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }
    }
}