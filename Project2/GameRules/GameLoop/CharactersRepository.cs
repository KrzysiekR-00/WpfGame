using GameRules.Characters;

namespace GameRules.GameLoop
{
    public class CharactersRepository
    {
        private const int MaxSize = 100;

        private readonly List<Character> _characters = new();

        public Character[] Unemployed => _characters.Where(u => u.Contract == null).ToArray();

        internal void Add(Character character)
        {
            if (_characters.Contains(character)) return;

            if (_characters.Count >= MaxSize) _characters.RemoveAt(0);

            _characters.Add(character);
        }

        internal void Add(Character[] characters)
        {
            foreach (var character in characters) Add(character);
        }
    }
}
