using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.SpellChanters
{
    public class FleshRiteChanters : IFleshRiteChanters
    {
        public List<FleshRite> GetFleshRites()
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