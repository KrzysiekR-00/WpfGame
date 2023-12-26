using GameRules.Combat.Combatables;
using GameRules.Combat.Moves;

namespace GameRules.Combat.BattleStats
{
    public class CombatableBattleStats
    {
        private readonly AggressiveMove[] _moves;

        public ICombatable Combatable { get; private set; }
        public float DamageCaused => _moves.Where(m => m.Combatable == Combatable).Sum(m => m.Damage);
        public float DamageTaken => _moves.Where(m => m.Target == Combatable).Sum(m => m.Damage);
        public float TotalEnergyCost => _moves.Where(m => m.Combatable == Combatable).Sum(m => m.EnergyCost);

        public CombatableBattleStats(ICombatable combatable, IBattleMakeableMove[] moves)
        {
            Combatable = combatable;

            _moves = moves.OfType<AggressiveMove>().ToArray();
        }
    }
}
