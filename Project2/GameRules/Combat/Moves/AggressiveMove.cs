using GameRules.Combat.Combatables;

namespace GameRules.Combat.Moves
{
    public class AggressiveMove : IBattleMakeableMove
    {
        public ICombatable Combatable { get; }
        public ICombatable Target { get; }

        public float Damage { get; }
        public float EnergyCost { get; }

        internal AggressiveMove(ICombatable combatable, ICombatable target)
        {
            Combatable = combatable;
            Target = target;

            AggressiveMoveEffectsCalculator calculator = new(combatable);

            Damage = calculator.GetDamageValue(Target);
            EnergyCost = calculator.GetEnergyCostValue();
        }

        public void Make()
        {
            Target.State.Health -= Damage;

            Combatable.State.Energy -= EnergyCost;
        }
    }
}
