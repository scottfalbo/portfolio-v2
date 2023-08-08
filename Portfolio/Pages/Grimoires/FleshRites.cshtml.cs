using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.SpellChanters;

namespace Portfolio.Pages.Grimoires
{
    public class FleshRitesModel : PageModel
    {
        private readonly IFleshRiteChanters _fleshRiteChanters;
        private readonly IEchoKeeperChanter _echoKeeperChanter;

        public bool IsWizardOverLord { get; set; }

        public List<FleshRite> FleshRites { get; set; }

        public FleshRitesModel(IFleshRiteChanters fleshRiteChanters, IEchoKeeperChanter echoKeeperChanter)
        {
            _fleshRiteChanters = fleshRiteChanters;
            _echoKeeperChanter = echoKeeperChanter;
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
                var echo = await _echoKeeperChanter.InscribeEcho(file);

                var fleshRite = new FleshRite()
                {
                    Name = name,
                    AltText = altText,
                    ImageUrl = echo.Uri.ToString(),
                    ThumbnailUrl = "https://placehold.co/100x177/939393/FFF",
                    StorageFileName = file.FileName,
                };

                await _fleshRiteChanters.ImbueEcho(fleshRite);
            }

            return Redirect("/Grimoires/FleshRites");
        }

        public async Task<IActionResult> OnPostShatterEcho(string id, string partitionKey)
        {
            await _echoKeeperChanter.BanishEcho(id);

            await _fleshRiteChanters.ShatterEcho(id, partitionKey);

            return Redirect("/Grimoires/FleshRites");
        }
    }
}