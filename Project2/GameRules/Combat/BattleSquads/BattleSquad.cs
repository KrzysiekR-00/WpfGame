namespace GameRules.Combat.BattleSquads
{
    public class BattleSquad
    {
        public BattleSquadMember[] Members { get; }

        internal BattleSquad? Enemy { get; private set; }

        internal BattleSquad(BattleSquadMember[] members)
        {
            foreach (var member in members) member.SetSquad(this);

            Members = members;
        }

        internal static void SetEnemies(BattleSquad squad1, BattleSquad squad2)
        {
            squad1.Enemy = squad2;
            squad2.Enemy = squad1;
        }

        internal bool IsSquadOutOfCombat()
        {
            return Members.All(m => m.IsOutOfCombat);
        }
    }
}
