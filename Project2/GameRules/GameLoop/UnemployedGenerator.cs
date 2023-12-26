using GameRules.Characters;

namespace GameRules.GameLoop
{
    internal static class UnemployedGenerator
    {
        internal static Character[] Generate(float playerTeamReputation, int size)
        {
            Character[] unemployed = new Character[size];

            int minLevel = (int)Math.Round(playerTeamReputation * 0.5f);
            int maxLevel = (int)Math.Round(playerTeamReputation * 1.5f);

            for (int i = 0; i < size; i++)
            {
                unemployed[i] = RandomCharacterCreator.Create(minLevel, maxLevel);
            }

            return unemployed;
        }
    }
}
