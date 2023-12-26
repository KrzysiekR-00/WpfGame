using GameRules.Characters.Factories;

namespace GameRules.Characters
{
    internal static class RandomCharacterCreator
    {
        internal static Character Create(int characterLevel)
        {
            return GetRandomCharacterFactory().Create(characterLevel);
        }

        internal static Character Create(int characterLevelMin, int characterLevelMax)
        {
            var characterLevel = new Random().Next(characterLevelMin, characterLevelMax + 1);
            return GetRandomCharacterFactory().Create(characterLevel);
        }

        private static ICharacterFactory GetRandomCharacterFactory()
        {
            int characterFactoryNumber = new Random().Next(2);
            return characterFactoryNumber switch
            {
                0 => new ElfFactory(),
                _ => new DwarfFactory(),
            };
        }
    }
}
