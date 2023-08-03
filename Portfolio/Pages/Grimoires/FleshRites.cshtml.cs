using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.SpellChanters;

namespace Portfolio.Pages.Grimoires
{
    public class FleshRitesModel : PageModel
    {
        private readonly IFleshRiteChanters _fleshRiteChanters;

        public FleshRitesModel(IFleshRiteChanters fleshRiteChanters)
        {
            _fleshRiteChanters = fleshRiteChanters;
        }

        public void OnGet()
        {
        }
    }
}