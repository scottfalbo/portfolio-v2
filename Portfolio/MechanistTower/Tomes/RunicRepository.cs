using Microsoft.Azure.Cosmos;
using Portfolio.MechanistTower.Scryers;

namespace Portfolio.MechanistTower.Tomes
{
    public class RunicRepository : IRunicRepository
    {
        private readonly Container _container;

        public RunicRepository(ICosmosTomeScryer cosmosTomeScryer)
        {
            var scryer = cosmosTomeScryer.ConjureScryer();
            _container = scryer.GetContainer("PaleSpecter", "Tomes");
        }
    }
}