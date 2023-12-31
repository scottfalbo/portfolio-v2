﻿using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.Tomes
{
    public interface IFleshRitesTome
    {
        Task ImbueFleshRiteAsync(FleshRite fleshRite);

        Task<FleshRite> GetFleshRiteAsync(string id, string partitionKey);

        Task<IEnumerable<FleshRite>> GetFleshRitesAsync();

        Task UpdateFleshRiteAsync(FleshRite updatedFleshRite);

        Task ShatterFleshRiteAsync(string id, string partitionKey);
    }
}