﻿using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.SpellChanters
{
    public interface IFleshRiteChanters
    {
        Task<List<FleshRite>> GetFleshRites();

        Task ImbueEcho(IFormFile[] files, string name, string altText);

        Task ShatterEcho(string id, string partitionKey, string fileName, string thumbnailFileName);
    }
}