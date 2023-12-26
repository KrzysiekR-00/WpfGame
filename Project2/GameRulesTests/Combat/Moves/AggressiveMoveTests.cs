using GameRules.Combat.Combatables;
using GameRules.Combat.Moves;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Combat.Moves
{
    [TestClass]
    public class AggressiveMoveTests
    {
        private ICombatable _aggressor = null!;
        private ICombatable _target = null!;
        private AggressiveMove _move = null!;

        [TestInitialize]
        public void Initialize()
        {
            _aggressor = CharactersHelpers.CreateElfCharacter(1);
            _target = CharactersHelpers.CreateElfCharacter(1);
            _move = new(_aggressor, _target);
        }

        [TestMethod]
        public void Make_SameLevelEnemies_TargetHealthIsLower()
        {
            var targetHealthBeforeMove = _target.State.Health;
            _move.Make();

            Assert.IsTrue(targetHealthBeforeMove > _target.State.Health);
        }

        [TestMethod]
        public void Make_SameLevelEnemies_AggressorEnergyIsLower()
        {
            var aggressorEnergyBeforeMove = _aggressor.State.Energy;
            _move.Make();

            Assert.IsTrue(aggressorEnergyBeforeMove > _aggressor.State.Energy);
        }
    }
}
