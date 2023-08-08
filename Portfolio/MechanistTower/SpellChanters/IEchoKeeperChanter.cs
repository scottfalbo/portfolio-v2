using Azure.Storage.Blobs;

namespace Portfolio.MechanistTower.SpellChanters
{
    public interface IEchoKeeperChanter
    {
        public Task<BlobClient> InscribeEcho(IFormFile file);

        public Task BanishEcho(string fileName);
    }
}