using GameRules.Combat.BattleSquads;

namespace GameRulesTests.TestsHelpers
{
    internal static class BattlesHelpers
    {
        internal static BattleSquadMember CreateBattleSquadMember(int memberLevel)
        {
            return new(CharactersHelpers.CreateElfCharacter(memberLevel));
        }

        internal static BattleSquadMember[] CreateBattleSquadMemberArray(int memberLevel, int length = 1)
        {
            var array = new BattleSquadMember[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = CreateBattleSquadMember(memberLevel);
            }

            return array;
        }

        internal static BattleSquad CreateBattleSquadWithOneMember(int memberLevel)
        {
            var members = CreateBattleSquadMemberArray(memberLevel, 1);
            return new BattleSquad(members);
        }

        internal static BattleSquad CreateBattleSquadWithOneMember(BattleSquadMember member)
        {
            return new BattleSquad(new[] { member });
        }

        internal static BattleSquad CreateEmptyBattleSquad()
        {
            return new BattleSquad(Array.Empty<BattleSquadMember>());
        }

        internal static void SetMemberEnergy(BattleSquadMember member, float value)
        {
            member.Combatable.State.Energy = value;
        }

        internal static void SetMemberHealth(BattleSquadMember member, float value)
        {
            member.Combatable.State.Health = value;
        }
    }
}
