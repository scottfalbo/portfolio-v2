using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Tomes;

namespace Portfolio.MechanistTower.SpellChanters
{
    public class FleshRiteChanters : IFleshRiteChanters
    {
        private readonly IFleshRitesTome _fleshRitesTome;
        private readonly IEchoKeeperChanter _echoKeeperChanter;

        public FleshRiteChanters(IFleshRitesTome fleshRitesTome, IEchoKeeperChanter echoKeeperChanter)
        {
            _fleshRitesTome = fleshRitesTome;
            _echoKeeperChanter = echoKeeperChanter;
        }

        public async Task<List<FleshRite>> GetFleshRites()
        {
            var fleshRites = await _fleshRitesTome.GetFleshRitesAsync();

            return fleshRites.ToList();
        }

        public async Task ImbueEcho(IFormFile[] files, string name, string altText)
        {

            foreach (var file in files)
            {
                var fleshRite = new FleshRite()
                {
                    Name = name,
                    AltText = altText,
                };

                await _echoKeeperChanter.InscribeEcho(file, fleshRite);

                await _fleshRitesTome.ImbueFleshRiteAsync(fleshRite);
            }
        }

        public async Task ShatterEcho(string id, string partitionKey)
        {
            await _fleshRitesTome.ShatterFleshRiteAsync(id, partitionKey);
        }
    }
}