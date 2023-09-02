using Portfolio.MechanistTower.PuzzleBoxWorkshop.CipherBox;

namespace MechanistTowerTrials.PuzzleBoxWorkshop
{
    [TestClass]
    public class CipherBoxTrials
    {
        [TestMethod]
        public void Test()
        {
            var cipherBox = new CipherBox(4, 4);
            Assert.IsNotNull(cipherBox);
        }
    }
}