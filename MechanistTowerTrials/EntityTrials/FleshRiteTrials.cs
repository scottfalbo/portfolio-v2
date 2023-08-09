using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.Entities.EternalSymbols;

namespace MechanistTowerTrials.EntityTrials
{
    [TestClass]
    public class FleshRiteTrials
    {
        [TestMethod]
        public void FleshRites_Constructor_AssignsEternalSymbol_PartitionKey()
        {
            var fleshRite = new FleshRite();

            var eternalSymbol = fleshRite.EternalSymbol;
            var expectedPartitionKey = eternalSymbol;

            Assert.AreEqual(OculusEchoCyphers.FleshRite, eternalSymbol);
            Assert.AreEqual(expectedPartitionKey, fleshRite.PartitionKey);
        }
    }
}