using GameRules.Combat.BattleSquads;
using GameRules.Combat.Combatables;
using GameRules.Combat.Moves;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Combat.Moves
{
    [TestClass]
    public class AggressiveMoveEffectsCalculatorTests
    {
        private ICombatable _aggressor = null!;
        private ICombatable _target = null!;
        private AggressiveMoveEffectsCalculator _calculator = null!;

        [TestInitialize]
        public void Initialize()
        {
            _aggressor = CharactersHelpers.CreateElfCharacter(1);
            _target = CharactersHelpers.CreateElfCharacter(1);
            _calculator = new AggressiveMoveEffectsCalculator(_aggressor);
        }

        [TestMethod]
        public void GetDamageValue_EqualLevelEnemies_GreaterThanZero()
        {
            var damageValue = _calculator.GetDamageValue(_target);

            Assert.IsTrue(damageValue > 0);
        }

        [TestMethod]
        public void GetEnergyCostValue_AggressiveMove_GreaterThanZero()
        {
            var energyCost = _calculator.GetEnergyCostValue();

            Assert.IsTrue(energyCost > 0);
        }

        [TestMethod]
        public void GetDamageValue_DifferentEnergyValue_HigherEnergyCausesHigherDamage()
        {
            _aggressor.State.Energy = 100;
            var highEnergyDamageValue = _calculator.GetDamageValue(_target);

            _aggressor.State.Energy = 10;
            var lowEnergyDamageValue = _calculator.GetDamageValue(_target);

            Assert.IsTrue(highEnergyDamageValue > lowEnergyDamageValue);
        }
    }
}
