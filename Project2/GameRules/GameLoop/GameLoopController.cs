using GameRules.Achievements;
using GameRules.Combat;
using GameRules.Combat.BattleStats;
using GameRules.Combat.Combatables;
using GameRules.Contracts;
using GameRules.Teams;
using GameRules.Teams.Factories;

namespace GameRules.GameLoop
{
    public class GameLoopController
    {
        public GameState GameState { get; private set; }

        private GameLoopController(GameState gameState)
        {
            GameState = gameState;
        }

        public static GameLoopController NewGame()
        {
            var team = new PlayerStartingTeamFactory().Create();
            var enemy = NextEnemyGenerator.Generate(team.Employer.Reputation);

            var charactersRepository = new CharactersRepository();
            charactersRepository.Add(team.Crew);

            int newGameUneployedCount = 3;
            var unemployed = UnemployedGenerator.Generate(team.Employer.Reputation, newGameUneployedCount);
            charactersRepository.Add(unemployed);

            var gameState = new GameState(1, team, enemy, charactersRepository, new BattlesResultsStats(), new Achievements.AchievementsCollection());

            return new GameLoopController(gameState);
        }

        public Battle StartBattle(PlayerBattleSquad playerBattleSquad)
        {
            return new Battle(playerBattleSquad, GameState.NextEnemy);
        }

        public void StartNextTurn(BattleResult battleResult)
        {
            EndTurn(battleResult);

            InitializeNextTurn();
        }

        private void EndTurn(BattleResult battleResult)
        {
            GameState.Team.Employer.RecalculateReputation();

            GameState.Team.PayWages(GameState.Turn);

            HandleBattleResult(battleResult);

            var newAchievements = AchievementTracker.VerifyAndGetNewAchievements(GameState.AchievementsCollection, GameState);
            foreach (var achievement in newAchievements)
            {
                GameState.Team.EarnAchievementReward(GameState.Turn, achievement);
            }
        }

        private void InitializeNextTurn()
        {
            var nextEnemy = NextEnemyGenerator.Generate(GameState.Team.Employer.Reputation);

            int newTurnUneployedCount = 1;
            var unemployed = UnemployedGenerator.Generate(GameState.Team.Employer.Reputation, newTurnUneployedCount);
            GameState.CharactersRepository.Add(unemployed);

            GameState = new GameState(GameState.Turn + 1, GameState.Team, nextEnemy, GameState.CharactersRepository, GameState.BattlesResultsStats, GameState.AchievementsCollection);

            ContractsManager.RemoveExpiredContracts(GameState.Team.Employer, GameState.Turn);

            StateRegenerator.Regenerate(GameState.Team.Crew);
            StateRegenerator.Regenerate(GameState.CharactersRepository.Unemployed);
        }

        private void HandleBattleResult(BattleResult battleResult)
        {
            GameState.Team.EarnBattleReward(GameState.Turn, BattleAwardCalculator.GetAwardForTeam(battleResult, GameState.NextEnemy));

            GameState.BattlesResultsStats.RegisterResult(battleResult, GameState.NextEnemy);
        }
    }
}
