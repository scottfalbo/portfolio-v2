using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.Tomes
{
    public interface ICryptCrawler
    {
        Task ImbueFleshRiteAsync(FleshRite fleshRite);

        Task<FleshRite> GetFleshRiteAsync(string id, string partitionKey);

        Task<IEnumerable<FleshRite>> GetFleshRitesAsync();

        Task UpdateFleshRiteAsync(FleshRite updatedFleshRite);

        Task DeleteFleshRiteAsync(string id, string partitionKey);
    }
}