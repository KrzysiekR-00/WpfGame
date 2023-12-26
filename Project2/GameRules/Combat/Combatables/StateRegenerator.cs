namespace GameRules.Combat.Combatables
{
    internal static class StateRegenerator
    {
        private const int HealthValue = 25;
        private const int EnergyValue = 35;

        internal static void Regenerate(ICombatable[] combatables)
        {
            for (int i = 0; i < combatables.Length; i++)
            {
                combatables[i].State.Health += HealthValue;
                combatables[i].State.Energy += EnergyValue;
            }
        }
    }
}
