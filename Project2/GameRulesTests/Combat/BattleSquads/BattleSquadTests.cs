using GameRules.Combat.BattleSquads;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Combat.BattleSquads
{
    [TestClass]
    public class BattleSquadTests
    {
        [TestMethod]
        public void Members_AddMember_OneMember()
        {
            var battleSquad = BattlesHelpers.CreateBattleSquadWithOneMember(1);

            Assert.AreEqual(1, battleSquad.Members.Length);
        }

        [TestMethod]
        public void Enemy_DefaultValue_Null()
        {
            var battleSquad = BattlesHelpers.CreateEmptyBattleSquad();

            Assert.AreEqual(null, battleSquad.Enemy);
        }

        [TestMethod]
        public void Enemy_AddEnemy_CorrectEnemy()
        {
            var battleSquad1 = BattlesHelpers.CreateEmptyBattleSquad();
            var battleSquad2 = BattlesHelpers.CreateEmptyBattleSquad();

            BattleSquad.SetEnemies(battleSquad1, battleSquad2);

            Assert.AreEqual(battleSquad1, battleSquad2.Enemy);
        }

        [TestMethod]
        public void IsSquadOutOfCombat_ZeroHealthMember_ReturnsTrue()
        {
            var battleSquad = BattlesHelpers.CreateBattleSquadWithOneMember(1);
            BattlesHelpers.SetMemberHealth(battleSquad.Members[0], 0);

            Assert.IsTrue(battleSquad.IsSquadOutOfCombat());
        }
    }
}
