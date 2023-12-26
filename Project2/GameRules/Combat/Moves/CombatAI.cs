using GameRules.Combat.BattleSquads;

namespace GameRules.Combat.Moves
{
    internal static class CombatAI
    {
        internal static AggressiveMove GetBestAggresiveMove(BattleSquadMember aggressor, BattleSquadMember[] targetsInCombat)
        {
            var possibleMoves = GetAllPossibleMoves(aggressor, targetsInCombat);

            return possibleMoves.OrderByDescending(m => m.Damage).First();
        }

        private static IEnumerable<AggressiveMove> GetAllPossibleMoves(BattleSquadMember aggressor, BattleSquadMember[] possibleTargets)
        {
            foreach (var target in possibleTargets) yield return new AggressiveMove(aggressor.Combatable, target.Combatable);
        }
    }
}
