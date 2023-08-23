using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.SpellChanters;

namespace Portfolio.Pages.Grimoires
{
    public class IllustrationsModel : PageModel
    {
        private readonly IIllustrationChanters _illustrationChanters;

        public bool IsWizardOverLord { get; set; }

        public List<Illustration> Echoes { get; set; }

        public IllustrationsModel(IIllustrationChanters fleshRiteChanters)
        {
            _illustrationChanters = fleshRiteChanters;
        }

        public async Task OnGet()
        {
            Echoes = await _illustrationChanters.GetIllustrations();

            IsWizardOverLord = User.Identity.IsAuthenticated;
        }

        public async Task<IActionResult> OnPostImbueEcho(IFormFile[] files, string name = "", string altText = "")
        {
            if (string.IsNullOrEmpty(altText) || string.IsNullOrWhiteSpace(altText))
            {
                altText = "Flesh Rite by Scott Falbo";
            }

            await _illustrationChanters.ImbueEcho(files, name, altText);

            return Redirect("/Grimoires/Illustrations");
        }

        public async Task<IActionResult> OnPostShatterEcho(string id, string partitionKey, string fileName, string thumbnailFileName)
        {
            await _illustrationChanters.ShatterEcho(id, partitionKey, fileName, thumbnailFileName);

            return Redirect("/Grimoires/Illustrations");
        }
    }
}