﻿using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Entities.EternalSymbols;
using Portfolio.MechanistTower.Tomes;

namespace Portfolio.MechanistTower.SpellChanters
{
    public class FleshRiteChanters : IFleshRiteChanters
    {
        private readonly ICryptCrawler _fleshRitesTome;

        public FleshRiteChanters(ICryptCrawler fleshRitesTome)
        {
            _fleshRitesTome = fleshRitesTome;
        }

        public async Task<List<FleshRite>> GetFleshRites()
        {
            var fleshRites = await _fleshRitesTome.GetFleshRitesAsync();

            return fleshRites.ToList();
        }

        public async Task ImbueEcho(FleshRite fleshRite)
        {
            await _fleshRitesTome.ImbueFleshRiteAsync(fleshRite);
        }
    }
}