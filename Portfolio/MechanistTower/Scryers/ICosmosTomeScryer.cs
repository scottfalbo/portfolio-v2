using Microsoft.Azure.Cosmos;

namespace Portfolio.MechanistTower.Scryers
{
    public interface ICosmosTomeScryer
    {
        CosmosClient ConjureScryer();
    }
}