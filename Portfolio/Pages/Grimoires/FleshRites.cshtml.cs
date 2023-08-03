using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.SpellChanters;

namespace Portfolio.Pages.Grimoires
{
    public class FleshRitesModel : PageModel
    {
        private readonly IFleshRiteChanters _fleshRiteChanters;

        public List<FleshRite> FleshRites { get; set; }

        public FleshRitesModel(IFleshRiteChanters fleshRiteChanters)
        {
            _fleshRiteChanters = fleshRiteChanters;
        }

        public void OnGet()
        {
            FleshRites = _fleshRiteChanters.GetFleshRites();
        }
    }
}