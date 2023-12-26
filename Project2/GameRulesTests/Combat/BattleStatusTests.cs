using GameRules.Combat;
using GameRules.Combat.BattleSquads;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Combat
{
    [TestClass]
    public class BattleStatusTests
    {
        private Battle _battle = null!;
        private BattleStatus _battleStatus = null!;

        [TestInitialize]
        public void Initialize()
        {
            var squad1 = BattlesHelpers.CreateBattleSquadWithOneMember(1);
            var squad2 = BattlesHelpers.CreateBattleSquadWithOneMember(1);
            _battle = new(squad1, squad2);
            _battleStatus = new(_battle);
        }

        [TestMethod]
        public void IsOver_OneSquadOutOfCombat_ReturnTrue()
        {
            BattlesHelpers.SetMemberHealth(_battle.BattleSquads[0].Members[0], 0);

            Assert.IsTrue(_battleStatus.IsOver);
        }

        [TestMethod]
        public void IsOver_BothSquadsInCombat_ReturnFalse()
        {
            Assert.IsFalse(_battleStatus.IsOver);
        }

        [TestMethod]
        public void GetBattleResultOrNull_OneSquadOutOfCombat_ReturnWinner()
        {
            BattlesHelpers.SetMemberHealth(_battle.BattleSquads[0].Members[0], 0);

            var result = _battle.BattleStatus.GetBattleResultOrNull();

            Assert.AreEqual(_battle.BattleSquads[1], result!.Value.Winner);
        }

        [TestMethod]
        public void GetBattleResultOrNull_BothSquadsOutOfCombat_WinnerIsNull()
        {
            BattlesHelpers.SetMemberHealth(_battle.BattleSquads[0].Members[0], 0);
            BattlesHelpers.SetMemberHealth(_battle.BattleSquads[1].Members[0], 0);

            var result = _battle.BattleStatus.GetBattleResultOrNull();

            Assert.AreEqual(null, result!.Value.Winner);
        }

        [TestMethod]
        public void GetBattleResultOrNull_BothSquadsInCombat_ReturnNull()
        {
            var result = _battle.BattleStatus.GetBattleResultOrNull();

            Assert.AreEqual(null, result);
        }
    }
}
