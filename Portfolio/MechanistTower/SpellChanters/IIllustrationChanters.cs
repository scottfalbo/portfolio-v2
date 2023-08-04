using Portfolio.MechanistTower.Entities;

namespace Portfolio.MechanistTower.SpellChanters
{
    public interface IIllustrationChanters
    {
        Task<List<Illustration>> GetIllustrations();
    }
}