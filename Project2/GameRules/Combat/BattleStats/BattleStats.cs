using GameRules.Combat.Combatables;
using GameRules.Combat.Moves;

namespace GameRules.Combat.BattleStats
{
    public class BattleStats
    {
        public CombatableBattleStats[] CombatableStats { get; private set; }

        public BattleStats(ICombatable[] combatables, IBattleMakeableMove[] moves)
        {
            CombatableStats = new CombatableBattleStats[combatables.Length];
            for (int i = 0; i < combatables.Length; i++)
            {
                CombatableStats[i] = new CombatableBattleStats(combatables[i], moves);
            }
        }
    }
}
