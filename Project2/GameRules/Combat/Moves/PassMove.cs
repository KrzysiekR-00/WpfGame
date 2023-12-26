using GameRules.Combat.Combatables;

namespace GameRules.Combat.Moves
{
    public class PassMove : IBattleMakeableMove
    {
        public ICombatable Combatable { get; }

        public void Make() { }

        internal PassMove(ICombatable combatable)
        {
            Combatable = combatable;
        }
    }
}
