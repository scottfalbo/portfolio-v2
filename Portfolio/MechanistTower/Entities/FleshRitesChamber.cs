using Portfolio.MechanistTower.Entities.EternalSymbols;

namespace Portfolio.MechanistTower.Entities
{
    public class FleshRitesChamber : Chamber
    {
        public List<FleshRite> FleshRiteEchoes { get; set; }

        public FleshRitesChamber() : base(ChamberCyphers.FleshRitesChamber)
        {
        }
    }
}