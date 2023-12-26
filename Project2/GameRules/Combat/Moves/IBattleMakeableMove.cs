using GameRules.Combat.Combatables;

namespace GameRules.Combat.Moves
{
    public interface IBattleMakeableMove
    {
        public ICombatable Combatable { get; }

        internal void Make();
    }
}
