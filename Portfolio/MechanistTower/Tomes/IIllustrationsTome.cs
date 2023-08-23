using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.Tomes
{
    public interface IIllustrationsTome
    {
        Task ImbueIllustrationAsync(Illustration illustration);

        Task<Illustration> GetIllustrationAsync(string id, string partitionKey);

        Task<IEnumerable<Illustration>> GetIllustrationAsync();

        Task UpdateIllustrationAsync(Illustration updatedIllustration);

        Task ShatterIllustrationAsync(string id, string partitionKey);
    }
}