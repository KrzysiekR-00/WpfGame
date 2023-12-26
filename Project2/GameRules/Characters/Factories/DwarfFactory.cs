using GameRules.Combat.Combatables;

namespace GameRules.Characters.Factories
{
    internal class DwarfFactory : ICharacterFactory
    {
        public Character Create(int level)
        {
            var name = CharactersNamesResource.GetRandomDwarfName();
            var attributes = GetAttributesOfLevel(level);

            var character = new Character(name, Race.Dwarf, level, new State(), attributes);

            return character;
        }

        private static Attributes GetAttributesOfLevel(int level)
        {
            return new Attributes(
                level * 2,
                level * 2,
                level / 3,
                level
                );
        }
    }
}
