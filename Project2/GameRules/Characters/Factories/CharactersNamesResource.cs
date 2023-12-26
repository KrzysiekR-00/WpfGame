namespace GameRules.Characters.Factories
{
    internal static class CharactersNamesResource
    {
        internal static string GetRandomElfName()
        {
            return ElfNames().GetRandom();
        }

        internal static string GetRandomDwarfName()
        {
            return DwarfNames().GetRandom();
        }

        private static string[] ElfNames()
        {
            return new[] { "Ithirae", "Dolel", "Shalheira", "Kyrrha", "Barahad", "Liluth", "Filaurel", "Ievos", "Uthorim", "Aegor", "Tathdel", "Hastos", "Irithiel", "Aelrindel", "Selakiir" };
        }

        private static string[] DwarfNames()
        {
            return new[] { "Bofar", "Thronin", "Dagnal", "Gloin", "Orin", "Durin", "Gundrik", "Faldor", "Balarin", "Orik", "Brynja", "Korgan", "Grimbold", "Gromnir", "Rurik" };
        }

        private static string GetRandom(this string[] strings)
        {
            Random random = new();
            int randomIndex = random.Next(strings.Length);
            return strings[randomIndex];
        }
    }
}
