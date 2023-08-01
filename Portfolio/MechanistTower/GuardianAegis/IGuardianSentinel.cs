namespace Portfolio.MechanistTower.GuardianAegis
{
    public interface IGuardianSentinel
    {
        Task<SanctumCorporeal> Authenticate(string userName, string password);
    }
}