using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.SpellChanters
{
    public interface IIllustrationChanters
    {
        Task<List<Illustration>> GetIllustrations();

        Task ImbueEcho(IFormFile[] files, string name, string altText);

        Task ShatterEcho(string id, string partitionKey, string fileName, string thumbnailFileName);
    }
}