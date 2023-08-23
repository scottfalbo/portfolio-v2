using Portfolio.MechanistTower.Entities;
using Riok.Mapperly.Abstractions;

namespace Portfolio.MechanistTower.Transmutators
{
    [Mapper]
    public partial class IllustrationTransmutator
    {
        public partial Illustration InfernalContractToIllustration(InfernalContract infernalContract);

        public partial InfernalContract IllustrationToInfernalContract(Illustration illustration);
    }
}