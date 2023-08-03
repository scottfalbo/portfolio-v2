namespace Portfolio.MechanistTower.Entities
{
    public abstract class InfernalContract
    {
        public string Id { get; set; }

        public string PartitionKey { get; set; }

        public string ChronicleCode { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; } = DateTimeOffset.UtcNow;

        public InfernalContract(string chronicleCode)
        {
            ChronicleCode = chronicleCode;
            Id = Guid.NewGuid().ToString();
            PartitionKey = $"{ChronicleCode}-{Id}";
        }
    }
}