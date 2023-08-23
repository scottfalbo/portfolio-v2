using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Tomes;

namespace Portfolio.MechanistTower.SpellChanters
{
    public class IllustrationChanters : IIllustrationChanters
    {
        private readonly IIllustrationsTome _illustrationsTome;
        private readonly IEchoKeeperChanter _echoKeeperChanter;

        public IllustrationChanters(IIllustrationsTome illustrationsTome, IEchoKeeperChanter echoKeeperChanter)
        {
            _illustrationsTome = illustrationsTome;
            _echoKeeperChanter = echoKeeperChanter;
        }

        public async Task<List<Illustration>> GetIllustrations()
        {
            var illustration = new List<Illustration>();

            for (var i = 0; i < 20; i++)
            {
                var fleshRite = new Illustration()
                {
                    Name = $"Illustration {i + 1}",
                    AltText = $"Illustration alt text {i + 1}",
                    Display = true,
                    ImageUrl = "https://placehold.co/1080x1920/939393/FFF",
                    ThumbnailUrl = "https://placehold.co/100x177/939393/FFF",
                };

                illustration.Add(fleshRite);
            }

            return illustration;
        }

        public Task ImbueEcho(IFormFile[] files, string name, string altText)
        {
            throw new NotImplementedException();
        }

        public Task ShatterEcho(string id, string partitionKey, string fileName, string thumbnailFileName)
        {
            throw new NotImplementedException();
        }
    }
}