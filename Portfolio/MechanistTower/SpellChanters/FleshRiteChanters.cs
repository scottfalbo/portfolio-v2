using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Entities.EternalSymbols;
using Portfolio.MechanistTower.Tomes.FleshRites;

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
            var fleshRites = new List<FleshRite>();

            for (var i = 0; i < 20; i++)
            {
                var fleshRite = new FleshRite()
                {
                    Name = $"Flesh Rite {i + 1}",
                    AltText = $"Flesh Rite alt text {i + 1}",
                    Display = true,
                    ImageUrl = "https://placehold.co/1080x1920",
                    ThumbnailUrl = "https://placehold.co/100x177",
                };

                fleshRites.Add(fleshRite);
            }

            return fleshRites;
        }
    }
}