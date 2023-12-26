using GameRules.Combat.BattleSquads;
using GameRules.Combat.Moves;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Combat.BattleSquads
{
    [TestClass]
    public class BattleSquadMemberTests
    {
        BattleSquadMember _battleSquadMember = null!;

        [TestInitialize]
        public void Initialize()
        {
            _battleSquadMember = BattlesHelpers.CreateBattleSquadMember(1);
        }

        [TestMethod]
        [DataRow(0, true)]
        [DataRow(100, false)]
        public void IsOutOfCombat_SpecificHealth_CorrectValue(float health, bool shouldBeOutOfCombat)
        {
            BattlesHelpers.SetMemberHealth(_battleSquadMember, health);

            Assert.AreEqual(shouldBeOutOfCombat, _battleSquadMember.IsOutOfCombat);
        }

        [TestMethod]
        public void MakeMove_NullSquad_PassMove()
        {
            var move = _battleSquadMember.MakeMove();

            Assert.IsTrue(move is PassMove);
        }

        [TestMethod]
        public void MakeMove_NullSquadEnemy_PassMove()
        {
            _ = CreateMemberSquad();

            var move = _battleSquadMember.MakeMove();

            Assert.IsTrue(move is PassMove);
        }

        [TestMethod]
        public void MakeMove_NullSquadEnemyMembers_AggressiveMove()
        {
            BattleSquad squad = CreateMemberSquad();

            BattleSquad enemySquad = new(Array.Empty<BattleSquadMember>());
            BattleSquad.SetEnemies(squad, enemySquad);

            var move = _battleSquadMember.MakeMove();

            Assert.IsTrue(move is PassMove);
        }

        [TestMethod]
        public void MakeMove_OutOfCombat_PassMove()
        {
            BattleSquad squad = CreateMemberSquad();

            BattleSquad enemySquad = BattlesHelpers.CreateEmptyBattleSquad();
            BattleSquad.SetEnemies(squad, enemySquad);

            BattlesHelpers.SetMemberEnergy(_battleSquadMember, 0);

            var move = _battleSquadMember.MakeMove();

            Assert.IsTrue(move is PassMove);
        }

        [TestMethod]
        public void MakeMove_InCombat_AggressiveMove()
        {
            BattleSquad squad = CreateMemberSquad();

            BattleSquad enemySquad = BattlesHelpers.CreateBattleSquadWithOneMember(1);
            BattleSquad.SetEnemies(squad, enemySquad);

            var move = _battleSquadMember.MakeMove();

            Assert.IsTrue(move is AggressiveMove);
        }

        private BattleSquad CreateMemberSquad()
        {
            return BattlesHelpers.CreateBattleSquadWithOneMember(_battleSquadMember);
        }
    }
}
