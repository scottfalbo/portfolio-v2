using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.MechanistTower.GuardianAegis;

namespace Portfolio.Pages
{
    public class SecretEntranceModel : PageModel
    {
        private readonly IGuardianSentinel _guardianSentinel;

        public SecretEntranceModel(IGuardianSentinel guardianSentinel)

        {
            _guardianSentinel = guardianSentinel;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string userName, string password)
        {
            var sanctumCorporeal = await _guardianSentinel.Authenticate(userName, password);

            if (sanctumCorporeal != null)
            {
                return RedirectToPage("/ArcaneIndex");
            }

            return Page();
        }
    }
}