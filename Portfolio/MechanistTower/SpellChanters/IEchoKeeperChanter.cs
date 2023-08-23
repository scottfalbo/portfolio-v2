using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.SpellChanters
{
    public interface IEchoKeeperChanter
    {
        public Task InscribeEcho(IFormFile file, OculusEcho echo);

        public Task BanishEcho(string fileName);
    }
}