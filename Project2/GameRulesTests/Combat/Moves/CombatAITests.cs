using GameRules.Combat.BattleSquads;
using GameRules.Combat.Moves;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Combat.Moves
{
    [TestClass]
    public class CombatAITests
    {
        [TestMethod]
        public void GetBestAggresiveMove_TwoDifferentEnemies_AttackWeakerEnemy()
        {
            BattleSquadMember aggressor = BattlesHelpers.CreateBattleSquadMember(10);
            BattleSquadMember weakerEnemy = BattlesHelpers.CreateBattleSquadMember(1);
            BattleSquadMember strongerEnemy = BattlesHelpers.CreateBattleSquadMember(20);

            var move = CombatAI.GetBestAggresiveMove(aggressor, new[] { weakerEnemy, strongerEnemy });

            Assert.AreEqual(weakerEnemy.Combatable, move.Target);
        }
    }
}
