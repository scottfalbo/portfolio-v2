using Microsoft.Azure.Cosmos;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Scryers;

namespace Portfolio.MechanistTower.Tomes
{
    public class IllustrationsTome : IIllustrationsTome
    {
        private readonly Container _container;

        public IllustrationsTome(ICosmosTomeScryer cosmosTomeScryer)
        {
            var scryer = cosmosTomeScryer.ConjureScryer();
            _container = scryer.GetContainer("PaleSpecter", "Tomes");
        }

        public Task<Illustration> GetIllustrationAsync(string id, string partitionKey)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Illustration>> GetIllustrationAsync()
        {
            throw new NotImplementedException();
        }

        public Task ImbueIllustrationAsync(Illustration illustration)
        {
            throw new NotImplementedException();
        }

        public Task ShatterIllustrationAsync(string id, string partitionKey)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIllustrationAsync(Illustration updatedIllustration)
        {
            throw new NotImplementedException();
        }
    }
}