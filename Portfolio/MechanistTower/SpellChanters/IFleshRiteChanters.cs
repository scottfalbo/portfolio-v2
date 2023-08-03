using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.SpellChanters
{
    public interface IFleshRiteChanters
    {
        Task<FleshRitesChamber> GetFleshRitesChamber();
    }
}