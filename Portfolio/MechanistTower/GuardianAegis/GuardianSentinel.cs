using Microsoft.AspNetCore.Identity;

namespace Portfolio.MechanistTower.GuardianAegis
{
    public class GuardianSentinel : IGuardianSentinel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public GuardianSentinel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
        {
            _userManager = userManager;
            _signInManager = signIn;
        }

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
                    IsRegistered = true
                };
            }

            return null;
        }

        public async Task<IdentityResult> UpdatePassword(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> UpdateUserName(string userId, string newName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.UserName = newName;
            return await _userManager.UpdateAsync(user);
        }
    }
}