using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.Tomes.FleshRites
{
    public interface IFleshRitesChamberTome
    {
        Task<FleshRitesChamber> GetChamberAsync(string partitionKey);

        Task UpdateChamberAsync(FleshRitesChamber chamber);
    }
}