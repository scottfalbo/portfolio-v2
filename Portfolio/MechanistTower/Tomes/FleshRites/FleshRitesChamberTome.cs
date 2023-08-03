using Microsoft.Azure.Cosmos;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Scryers;

namespace Portfolio.MechanistTower.Tomes.FleshRites
{
    public class FleshRitesChamberTome : IFleshRitesChamberTome
    {
        private readonly Container _container;

        public FleshRitesChamberTome(ICosmosTomeScryer cosmosTomeScryer)
        {
            var scryer = cosmosTomeScryer.ConjureScryer();
            _container = scryer.GetContainer("PaleSpecter", "Tomes");
        }

        public async Task<FleshRitesChamber> GetChamberAsync(string partitionKey)
        {
            var chamber = await _container.ReadItemAsync<FleshRitesChamber>(partitionKey, new PartitionKey(partitionKey));
            return chamber.Resource;
        }

        public async Task UpdateChamberAsync(FleshRitesChamber chamber)
        {
            await _container.ReplaceItemAsync(chamber, chamber.PartitionKey, new PartitionKey(chamber.PartitionKey));
        }
    }
}