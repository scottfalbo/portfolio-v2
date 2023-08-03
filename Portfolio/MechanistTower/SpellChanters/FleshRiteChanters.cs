using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Entities.EternalSymbols;
using Portfolio.MechanistTower.Tomes.FleshRites;

namespace Portfolio.MechanistTower.SpellChanters
{
    public class FleshRiteChanters : IFleshRiteChanters
    {
        private readonly IFleshRitesTome _fleshRitesTome;
        private readonly IFleshRitesChamberTome _fleshRitesChamberTome;

        public FleshRiteChanters(IFleshRitesTome fleshRitesTome, IFleshRitesChamberTome fleshRitesChamberTome)
        {
            _fleshRitesTome = fleshRitesTome;
            _fleshRitesChamberTome = fleshRitesChamberTome;
        }

        public async Task<FleshRitesChamber> GetFleshRitesChamber()
        {
            // TODO: replace with actual repository call
            var fleshRitesChamber = new FleshRitesChamber()
            {
                Name = "Flesh Rites Chamber",
                Synopsis = "Runic incantations whisper in the mystic chamber, where arcane symbols dance in ethereal light. Enchanted scrolls and celestial reflections blend in the secret realms of alchemical magic. Through the veil of hidden truths, sorcerous echoes beckon, unveiling the wisdom of otherworldly dimensions.",
                FleshRiteEchoes = GetFleshRites()
            };

            return fleshRitesChamber;
        }

        private static List<FleshRite> GetFleshRites()
        {
            var fleshRites = new List<FleshRite>();

            for (var i = 0; i < 20; i++)
            {
                var fleshRite = new FleshRite()
                {
                    Name = "Flesh Rite",
                    AltText = "Flesh Rite alt text",
                    Display = true,
                    ImageUrl = "https://placehold.co/1080x1920",
                    ThumbnailUrl = "https://placehold.co/80x80",
                };

                fleshRites.Add(fleshRite);
            }

            return fleshRites;
        }
    }
}