using Microsoft.AspNetCore.Identity;

namespace Portfolio.MechanistTower.GuardianAegis
{
    public interface IGuardianSentinel
    {
        Task<SanctumCorporeal> Authenticate(string userName, string password);

        Task<IdentityResult> UpdatePassword(string userId, string currentPassword, string newPassword);

        Task<IdentityResult> UpdateUserName(string userId, string newName);
    }
}