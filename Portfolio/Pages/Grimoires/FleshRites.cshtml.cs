using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.SpellChanters;
using System.Runtime.CompilerServices;

namespace Portfolio.Pages.Grimoires
{
    public class FleshRitesModel : PageModel
    {
        private readonly IFleshRiteChanters _fleshRiteChanters;

        public bool IsWizardOverLord { get; set; }

        public List<FleshRite> FleshRites { get; set; }

        public FleshRitesModel(IFleshRiteChanters fleshRiteChanters)
        {
            _fleshRiteChanters = fleshRiteChanters;
        }

        public async Task OnGet()
        {
            FleshRites = await _fleshRiteChanters.GetFleshRites();

            IsWizardOverLord = User.Identity.IsAuthenticated;
        }
    }
}