using GameRules.Characters;
using GameRules.Characters.Factories;

namespace GameRulesTests.TestsHelpers
{
    internal static class CharactersHelpers
    {
        internal static Character CreateElfCharacter(int level)
        {
            return new ElfFactory().Create(level);
        }
    }
}