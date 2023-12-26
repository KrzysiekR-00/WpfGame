using GameRules.Combat.BattleSquads;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Combat.BattleSquads
{
    [TestClass]
    public class BattleSquadMembersMovesOrderTests
    {
        [TestMethod]
        public void GetMovesOrder_TwoDifferentMembers_HigherInitiativeMemberFirst()
        {
            var higherInitiativeCharacter = BattlesHelpers.CreateBattleSquadMember(10);
            var lowerInitiativeCharacter = BattlesHelpers.CreateBattleSquadMember(1);

            BattleSquadMember[] members = new[] { higherInitiativeCharacter, lowerInitiativeCharacter };

            var movesOrder = BattleSquadMembersMovesOrder.GetMovesOrder(members);

            Assert.AreEqual(higherInitiativeCharacter, movesOrder[0]);
        }
    }
}
