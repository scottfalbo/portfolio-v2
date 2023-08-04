using Portfolio.MechanistTower.Entities.EternalSymbols;

namespace Portfolio.MechanistTower.Entities
{
    public class Illustration : OculusEcho
    {
        public string Medium { get; set; }

        public string Size { get; set; }

        public bool IsForSale { get; set; }

        public decimal Price { get; set; }

        public Illustration() : base(OculusEchoCyphers.Illustrations)
        {
        }
    }
}