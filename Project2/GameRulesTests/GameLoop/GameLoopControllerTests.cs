using GameRules.Combat;
using GameRules.GameLoop;
using GameRules.Teams;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.GameLoop
{
    [TestClass]
    public class GameLoopControllerTests
    {
        private GameLoopController gameLoopController = null!;

        [TestInitialize]
        public void Initialize()
        {
            gameLoopController = GameLoopController.NewGame();
        }

        [TestMethod]
        public void NewGame_CreateNewGameLoop_TurnEqualsOne()
        {
            Assert.AreEqual(1, gameLoopController.GameState.Turn);
        }

        [TestMethod]
        public void NewGame_CreateNewGameLoop_NextEnemyIsNotNull()
        {
            Assert.AreNotEqual(null, gameLoopController.GameState.NextEnemy);
        }

        [TestMethod]
        public void NewGame_CreateNewGameLoop_UnemployedArrayLengthIsGreaterThanZero()
        {
            Assert.IsTrue(gameLoopController.GameState.CharactersRepository.Unemployed.Length > 0);
        }

        [TestMethod]
        public void StartBattle_DefaultTeam_BattleIsWithNextEnemy()
        {
            var battle = StartBattle();

            Assert.IsTrue(battle.BattleSquads.Contains(gameLoopController.GameState.NextEnemy));
        }

        [TestMethod]
        public void StartNextTurn_DummyBattleResult_TurnEqualsTwo()
        {
            gameLoopController.StartNextTurn(new BattleResult());

            Assert.AreEqual(2, gameLoopController.GameState.Turn);
        }

        private Battle StartBattle()
        {
            var team = gameLoopController.GameState.Team;
            TeamsHelpers.AddContractsToTeam(team, 3);

            var playerBattleSquad = PlayerBattleSquad.Create(team.Crew[0], team.Crew[1], team.Crew[2]);
            return gameLoopController.StartBattle(playerBattleSquad);
        }
    }
}
