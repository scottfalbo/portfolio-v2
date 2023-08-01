namespace Portfolio.MechanistTower.Entities
{
    public class InfernalContract
    {
        public string id { get; set; } = Guid.NewGuid().ToString();

        public string partitionKey { get; set; }
    }
}