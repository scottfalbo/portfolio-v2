using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.Tomes
{
    public interface IFleshRitesTome
    {
        Task CreateFleshRiteAsync(FleshRite fleshRite);

        Task<FleshRite> GetFleshRiteAsync(string id, string partitionKey);

        Task<IEnumerable<FleshRite>> GetFleshRitesAsync();

        Task UpdateFleshRiteAsync(string id, string partitionKey, FleshRite updatedFleshRite);

        Task DeleteFleshRiteAsync(string id, string partitionKey);
    }
}