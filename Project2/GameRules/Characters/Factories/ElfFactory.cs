using GameRules.Combat.Combatables;

namespace GameRules.Characters.Factories
{
    internal class ElfFactory : ICharacterFactory
    {
        public Character Create(int level)
        {
            var name = CharactersNamesResource.GetRandomElfName();
            var attributes = GetAttributesOfLevel(level);

            var character = new Character(name, Race.Elf, level, new State(), attributes);

            return character;
        }

        private static Attributes GetAttributesOfLevel(int level)
        {
            return new Attributes(
                level,
                level * 2,
                level / 3,
                level * 2
                );
        }
    }
}
