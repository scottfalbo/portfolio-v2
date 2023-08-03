using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Scryers;
using System.Net;

namespace Portfolio.MechanistTower.Tomes.FleshRites
{
    public class FleshRitesTome : IFleshRitesTome
    {
        private readonly Container _container;

        public FleshRitesTome(ICosmosTomeScryer cosmosTomeScryer)
        {
            var scryer = cosmosTomeScryer.ConjureScryer();
            _container = scryer.GetContainer("PaleSpecter", "Tomes");
        }

        public async Task CreateFleshRiteAsync(FleshRite fleshRite)
        {
            await _container.CreateItemAsync(fleshRite, new PartitionKey(fleshRite.PartitionKey));
        }

        public async Task<IEnumerable<FleshRite>> GetFleshRitesAsync()
        {
            var fleshRites = new List<FleshRite>();

            var iterator = _container.GetItemLinqQueryable<FleshRite>().ToFeedIterator();
            while (iterator.HasMoreResults)
            {
                var results = await iterator.ReadNextAsync();
                fleshRites.AddRange(results);
            }

            return fleshRites;
        }

        public async Task<FleshRite> GetFleshRiteAsync(string id, string partitionKey)
        {
            try
            {
                ItemResponse<FleshRite> response = await _container.ReadItemAsync<FleshRite>(id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdateFleshRiteAsync(string id, string partitionKey, FleshRite updatedFleshRite)
        {
            try
            {
                await _container.ReplaceItemAsync(updatedFleshRite, id, new PartitionKey(partitionKey));
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException($"FleshRite with id '{id}' not found.");
            }
        }

        public async Task DeleteFleshRiteAsync(string id, string partitionKey)
        {
            try
            {
                await _container.DeleteItemAsync<FleshRite>(id, new PartitionKey(partitionKey));
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException($"FleshRite with id '{id}' not found.");
            }
        }
    }
}