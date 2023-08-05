﻿using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Scryers;
using Portfolio.MechanistTower.Transmutators;
using System.Net;

namespace Portfolio.MechanistTower.Tomes
{
    public class FleshRitesTome : IFleshRitesTome
    {
        private readonly Container _container;

        private readonly FleshRiteTransmutator _transmutator;

        public FleshRitesTome(ICosmosTomeScryer cosmosTomeScryer)
        {
            var scryer = cosmosTomeScryer.ConjureScryer();
            _container = scryer.GetContainer("PaleSpecter", "Tomes");

            _transmutator = new FleshRiteTransmutator();
        }

        public async Task ImbueFleshRiteAsync(FleshRite fleshRite)
        {
            var infernalContract = _transmutator.FleshRiteToInfernalContract(fleshRite);

            await _container.CreateItemAsync(infernalContract, new PartitionKey(infernalContract.PartitionKey));
        }

        public async Task<IEnumerable<FleshRite>> GetFleshRitesAsync()
        {
            var fleshRites = new List<FleshRite>();

            var query = _container.GetItemLinqQueryable<InfernalContract>()
                .Where(x => x.EternalSymbol == "FleshRites")
                .ToFeedIterator();

            while (query.HasMoreResults)
            {
                var results = await query.ReadNextAsync();

                foreach (var infernalContract in results)
                {
                    var fleshRite = _transmutator.InfernalContractToFleshRite(infernalContract);
                    fleshRites.Add(fleshRite);
                }
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

        public async Task UpdateFleshRiteAsync(FleshRite updatedFleshRite)
        {
            var id = updatedFleshRite.Id;
            var partitionKey = updatedFleshRite.PartitionKey;

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