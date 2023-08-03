namespace Portfolio.MechanistTower.Entities
{
    public abstract class Chamber : InfernalContract
    {
        public string Name { get; set; }

        public Chamber(string cypher) : base(cypher)
        {
        }
    }
}