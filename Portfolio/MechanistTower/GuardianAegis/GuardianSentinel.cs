using Microsoft.AspNetCore.Identity;

namespace Portfolio.MechanistTower.GuardianAegis
{
    public class GuardianSentinel : IGuardianSentinel
    {
        private readonly UserManager<WizardOverlord> _userManager;
        private readonly SignInManager<WizardOverlord> _signInManager;

        public GuardianSentinel(UserManager<WizardOverlord> userManager, SignInManager<WizardOverlord> signin)
        {
            _userManager = userManager;
            _signInManager = signin;
        }

        /// <summary>
        /// Logs user in.
        /// </summary>
        public async Task<SanctumCorporeal> Authenticate(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);

                return new SanctumCorporeal
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user),
                    IsRegistered = true
                };
            }
            return null;
        }
    }
}