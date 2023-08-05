using Microsoft.Azure.Cosmos;
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
    }
}