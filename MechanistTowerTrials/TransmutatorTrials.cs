using MechanistTowerTrials.SorcerySupport;
using Portfolio.MechanistTower.Entities.EternalSymbols;
using Portfolio.MechanistTower.Transmutators;

namespace MechanistTowerTrials
{
    [TestClass]
    public class TransmutatorTrials
    {
        [TestMethod]
        public void FleshRiteTransmutator_FleshRiteToInfernalContract()
        {
            var date = DateTimeOffset.Now;

            var fleshRite = new OculusEchoScribe()
                .WithName("test-name")
                .WithAltText("test-alt-text")
                .WithCreatedDateTime(date)
                .WithDisplay(true)
                .WithImageUrl("test-image-url")
                .WithThumbnailUrl("test-thumbnail-url")
                .BuildFleshRite();

            var transmutator = new FleshRiteTransmutator();

            var infernalContract = transmutator.FleshRiteToInfernalContract(fleshRite);

            Assert.IsNotNull(infernalContract);
            Assert.AreEqual(fleshRite.Name, infernalContract.Name);
            Assert.AreEqual(fleshRite.AltText, infernalContract.AltText);
            Assert.AreEqual(fleshRite.CreatedDateTime, infernalContract.CreatedDateTime);
            Assert.AreEqual(fleshRite.Display, infernalContract.Display);
            Assert.AreEqual(fleshRite.ImageUrl, infernalContract.ImageUrl);
            Assert.AreEqual(fleshRite.ThumbnailUrl, infernalContract.ThumbnailUrl);
            Assert.AreEqual(fleshRite.EternalSymbol, OculusEchoCyphers.FleshRite);
        }

        [TestMethod]
        public void FleshRiteTransmutator_InfernalContractToFleshRite()
        {
            var date = DateTimeOffset.Now;
            var id = Guid.NewGuid().ToString();

            var infernalContract = new InfernalContractScribe()
                .WithName("test-name")
                .WithAltText("test-alt-text")
                .WithCreatedDateTime(date)
                .WithDisplay(true)
                .WithEternalSymbol(OculusEchoCyphers.FleshRite)
                .WithId(id)
                .WithImageUrl("test-image-url")
                .WithPartitionKey($"{OculusEchoCyphers.FleshRite}-{id}")
                .WithThumbnailUrl("test-thumbnail-url")
                .WithEternalSymbol(OculusEchoCyphers.FleshRite)
                .Build();

            var transmutator = new FleshRiteTransmutator();

            var fleshRite = transmutator.InfernalContractToFleshRite(infernalContract);

            Assert.IsNotNull(fleshRite);
            Assert.AreEqual(infernalContract.Name, fleshRite.Name);
            Assert.AreEqual(infernalContract.AltText, fleshRite.AltText);
            Assert.AreEqual(infernalContract.CreatedDateTime, fleshRite.CreatedDateTime);
            Assert.AreEqual(infernalContract.Display, fleshRite.Display);
            Assert.AreEqual(infernalContract.EternalSymbol, fleshRite.EternalSymbol);
            Assert.AreEqual(infernalContract.Id, fleshRite.Id);
            Assert.AreEqual(infernalContract.ImageUrl, fleshRite.ImageUrl);
            Assert.AreEqual(infernalContract.PartitionKey, fleshRite.PartitionKey);
            Assert.AreEqual(infernalContract.ThumbnailUrl, fleshRite.ThumbnailUrl);
        }
    }
}