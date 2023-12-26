using GameRules.Combat.Combatables;

namespace GameRules.Combat.Moves
{
    internal class AggressiveMoveEffectsCalculator
    {
        private readonly ICombatable _aggressor;

        internal AggressiveMoveEffectsCalculator(ICombatable aggressor)
        {
            _aggressor = aggressor;
        }

        internal float GetDamageValue(ICombatable target)
        {
            return _aggressor.BaseAttributes.Damage * GetEnergyModifier() / target.BaseAttributes.Armor;
        }

        internal float GetEnergyCostValue()
        {
            float baseEnergyCost = 5;
            return baseEnergyCost + baseEnergyCost / _aggressor.BaseAttributes.Stamina;
        }

        private float GetEnergyModifier()
        {
            var modifier = 1 - (100 - _aggressor.State.Energy) / 150;

            modifier = Math.Max(modifier, 0.3f);
            modifier = Math.Min(modifier, 1);

            return modifier;
        }
    }
}
