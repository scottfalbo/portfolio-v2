namespace Portfolio.MechanistTower.Entities
{
    public abstract class InfernalContract
    {
        public string Id { get; set; }

        public string PartitionKey { get; set; }

        public string EternalSymbol { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; } = DateTimeOffset.UtcNow;

        public InfernalContract(string chronicleCode)
        {
            EternalSymbol = chronicleCode;
            Id = Guid.NewGuid().ToString();
            PartitionKey = $"{EternalSymbol}-{Id}";
        }
    }
}