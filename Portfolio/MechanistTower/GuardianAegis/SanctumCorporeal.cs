namespace Portfolio.MechanistTower.GuardianAegis
{
    public class SanctumCorporeal
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public bool IsRegistered { get; set; }
    }
}