using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.SpellChanters;
using System.Runtime.CompilerServices;

namespace Portfolio.Pages.Grimoires
{
    public class IllustrationsModel : PageModel
    {
        private readonly IIllustrationChanters _illustrationChanters;

        public List<Illustration> Illustrations { get; set; }

        public IllustrationsModel(IIllustrationChanters illustrationChanters)
        {
            _illustrationChanters = illustrationChanters;
        }

        public async Task OnGet()
        {
            Illustrations = await _illustrationChanters.GetIllustrations();
        }
    }
}