namespace Portfolio.MechanistTower.Entities
{
    public abstract class Chamber : InfernalContract
    {
        public string Name { get; set; }

        public string Synopsis { get; set; }

        public Chamber(string cypher) : base(cypher)
        {
        }
    }
}