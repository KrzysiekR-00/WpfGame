using GameRules.Combat.BattleSquads;
using GameRules.Combat.Combatables;

namespace GameRules.Teams
{
    public class PlayerBattleSquad : BattleSquad
    {
        public const int NumberOfMembersInSquad = 3;

        private PlayerBattleSquad(BattleSquadMember[] battleSquadMembers) : base(battleSquadMembers)
        {
        }

        public static PlayerBattleSquad Create(ICombatable combatable1, ICombatable combatable2, ICombatable combatable3)
        {
            var combatables = new ICombatable[] { combatable1, combatable2, combatable3 };
            var battleSquadMembers = combatables.Select(c => new BattleSquadMember(c)).ToArray();
            return new PlayerBattleSquad(battleSquadMembers);
        }
    }
}
