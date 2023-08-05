using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Tomes;

namespace Portfolio.MechanistTower.SpellChanters
{
    public class FleshRiteChanters : IFleshRiteChanters
    {
        private readonly IFleshRitesTome _fleshRitesTome;

        public FleshRiteChanters(IFleshRitesTome fleshRitesTome)
        {
            _fleshRitesTome = fleshRitesTome;
        }

        public async Task<List<FleshRite>> GetFleshRites()
        {
            var fleshRites = await _fleshRitesTome.GetFleshRitesAsync();

            return fleshRites.ToList();
        }

        public async Task ImbueEcho(FleshRite fleshRite)
        {
            await _fleshRitesTome.ImbueFleshRiteAsync(fleshRite);
        }

        public async Task ShatterEcho(string id, string partitionKey)
        {
            await _fleshRitesTome.ShatterFleshRiteAsync(id, partitionKey);
        }
    }
}