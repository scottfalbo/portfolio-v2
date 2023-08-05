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

            foreach (var file in files)
            {
                // TODO: add blob storage stuff here and get an actual url
                var fleshRite = new FleshRite()
                {
                    Name = name,
                    AltText = altText,
                    ImageUrl = "https://placehold.co/1080x1920/939393/FFF",
                    ThumbnailUrl = "https://placehold.co/100x177/939393/FFF"
                };

                await _fleshRiteChanters.ImbueEcho(fleshRite);
            }

            return Redirect("/Grimoires/FleshRites");
        }
    }
}