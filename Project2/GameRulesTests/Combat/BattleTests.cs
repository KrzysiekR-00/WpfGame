using GameRules.Combat;
using GameRules.Combat.BattleSquads;
using GameRules.Combat.Moves;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Combat
{
    [TestClass]
    public class BattleTests
    {
        private BattleSquad _lowerReputationSquad = null!;
        private BattleSquad _higherReputationSquad = null!;
        private Battle _battle = null!;

        [TestInitialize]
        public void Initialize()
        {
            _lowerReputationSquad = BattlesHelpers.CreateBattleSquadWithOneMember(1);
            _higherReputationSquad = BattlesHelpers.CreateBattleSquadWithOneMember(10);
            _battle = new(_lowerReputationSquad, _higherReputationSquad);
        }

        [TestMethod]
        public void TryDoNextRound_OneRound_MovesGreaterThanZero()
        {
            _battle.TryDoNextRound(out IBattleMakeableMove[] moves);

            Assert.IsTrue(moves.Length > 0);
        }

        [TestMethod]
        public void TryDoNextRound_OneRound_CanBeDone()
        {
            var tryDoResult = _battle.TryDoNextRound(out _);

            Assert.IsTrue(tryDoResult);
        }

        [TestMethod]
        public void TryDoNextRound_OneSquadOutOfCombat_CannotBeDone()
        {
            BattlesHelpers.SetMemberHealth(_lowerReputationSquad.Members[0], 0);

            var tryDoResult = _battle.TryDoNextRound(out _);

            Assert.IsFalse(tryDoResult);
        }

        [TestMethod, Timeout(1000)]
        public void TryDoNextRound_DoRoundsUntilBattleIsOver_HigherReputationSquadIsWinner()
        {
            while (!_battle.BattleStatus.IsOver)
            {
                _battle.TryDoNextRound(out _);
            }

            var result = _battle.BattleStatus.GetBattleResultOrNull();

            Assert.AreEqual(_higherReputationSquad, result!.Value.Winner);
        }
    }
}
