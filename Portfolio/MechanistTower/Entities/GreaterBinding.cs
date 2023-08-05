namespace Portfolio.MechanistTower.Entities
{
    public abstract class GreaterBinding
    {
        public string Id { get; set; }

        public string PartitionKey { get; set; }

        public string EternalSymbol { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; } = DateTimeOffset.UtcNow;

        public GreaterBinding(string chronicleCode)
        {
            EternalSymbol = chronicleCode;
            Id = Guid.NewGuid().ToString();
            PartitionKey = $"{EternalSymbol}-{Id}";
        }
    }
}