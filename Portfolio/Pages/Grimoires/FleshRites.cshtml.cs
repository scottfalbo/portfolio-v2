using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.SpellChanters;
using System.Runtime.CompilerServices;

namespace Portfolio.Pages.Grimoires
{
    public class FleshRitesModel : PageModel
    {
        private readonly IFleshRiteChanters _fleshRiteChanters;

        public string Name { get; set; }

        public string Synopsis { get; set; }

        public List<FleshRite> FleshRites { get; set; }

        public FleshRitesModel(IFleshRiteChanters fleshRiteChanters)
        {
            _fleshRiteChanters = fleshRiteChanters;
        }

        public async Task OnGet()
        {
            var fleshRitesChamber = await _fleshRiteChanters.GetFleshRitesChamber();

            Name = fleshRitesChamber.Name;
            Synopsis = fleshRitesChamber.Synopsis;
            FleshRites = fleshRitesChamber.FleshRiteEchoes;

            await Console.Out.WriteLineAsync("");
        }
    }
}