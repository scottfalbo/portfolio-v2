using Portfolio.MechanistTower.Entities;
using Riok.Mapperly.Abstractions;

namespace Portfolio.MechanistTower.Transmutators
{
    [Mapper]
    public partial class FleshRiteTransmutator
    {
        public partial FleshRite InfernalContractToFleshRite(InfernalContract infernalContract);

        public partial InfernalContract FleshRiteToInfernalContract(FleshRite fleshRite);
    }
}