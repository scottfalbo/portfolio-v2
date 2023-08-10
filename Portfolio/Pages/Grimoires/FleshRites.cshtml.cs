using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.SpellChanters;

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

        public async Task<IActionResult> OnPostImbueEcho(IFormFile[] files, string name = "", string altText = "")
        {
            if (string.IsNullOrEmpty(altText) || string.IsNullOrWhiteSpace(altText))
            {
                altText = "Flesh Rite by Scott Falbo";
            }

            await _fleshRiteChanters.ImbueEcho(files, name, altText);

            return Redirect("/Grimoires/FleshRites");
        }

        public async Task<IActionResult> OnPostShatterEcho(string id, string partitionKey, string fileName)
        {
            await _fleshRiteChanters.ShatterEcho(id, partitionKey);

            return Redirect("/Grimoires/FleshRites");
        }
    }
}