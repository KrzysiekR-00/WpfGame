using GameRules.Combat.BattleSquads;

namespace GameRules.Combat
{
    public readonly struct BattleResult
    {
        public BattleSquad? Winner { get; }

        internal BattleResult(BattleSquad? winner)
        {
            Winner = winner;
        }
    }
}
