using NSubstitute;
using Portfolio.MechanistTower.Entities;
using Portfolio.MechanistTower.SpellChanters;
using Portfolio.MechanistTower.Tomes;

namespace MechanistTowerTrials.ChanterTrials
{
    [TestClass]
    public class FleshRiteChanterTrials
    {
        private IFleshRitesTome _fleshRitesTomeVisage;
        private IEchoKeeperChanter _echoKeeperChanterVisage;

        private IFleshRiteChanters _fleshRiteChanters;

        [TestMethod]
        public async Task GetFleshRites_ReturnsFleshRites()
        {
            var fleshRites = new List<FleshRite>
            {
                new FleshRite(),
                new FleshRite(),
                new FleshRite()
            };

            _fleshRitesTomeVisage.GetFleshRitesAsync().Returns(fleshRites);

            var results = await _fleshRiteChanters.GetFleshRites();

            await _fleshRitesTomeVisage.Received(1).GetFleshRitesAsync();
            Assert.AreEqual(3, results.Count);
        }

        //[TestMethod]
        //public async Task ImbueEcho_CallsTome()
        //{
        //    var fleshRite = new FleshRite();

        //    await _fleshRiteChanters.ImbueEcho(fleshRite);

        //    await _fleshRitesTomeVisage.Received(1).ImbueFleshRiteAsync(fleshRite);
        //}

        [TestInitialize]
        public void Initialize()
        {
            _fleshRitesTomeVisage = Substitute.For<IFleshRitesTome>();
            _echoKeeperChanterVisage = Substitute.For<IEchoKeeperChanter>();

            _fleshRiteChanters = new FleshRiteChanters(_fleshRitesTomeVisage, _echoKeeperChanterVisage);
        }
    }
}