using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.SpellChanters
{
    public interface IFleshRiteChanters
    {
        Task<List<FleshRite>> GetFleshRites();

        Task ImbueEcho(FleshRite fleshRite);

        Task ShatterEcho(string id, string partitionKey);
    }
}