using GameRules.Characters;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Characters
{
    [TestClass]
    public class CharacterFactoriesTests
    {
        [TestMethod]
        public void Create_ElfCharacter_HasProperRace()
        {
            var character = CharactersHelpers.CreateElfCharacter(0);

            Assert.AreEqual(Race.Elf, character.Race);
        }
    }
}
