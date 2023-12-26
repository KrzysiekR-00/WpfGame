using GameRules.Achievements;
using GameRules.Combat.BattleSquads;
using GameRules.Combat.BattleStats;
using GameRules.Teams;

namespace GameRules.GameLoop
{
    public class GameState
    {
        public int Turn { get; }
        public Team Team { get; }
        public BattleSquad NextEnemy { get; }
        public CharactersRepository CharactersRepository { get; }
        public BattlesResultsStats BattlesResultsStats { get; }
        public AchievementsCollection AchievementsCollection { get; }

        internal GameState(int turn, Team team, BattleSquad nextEnemy, CharactersRepository charactersRepository, BattlesResultsStats battlesResultsStats, AchievementsCollection achievementsCollection)
        {
            Turn = turn;
            Team = team;
            NextEnemy = nextEnemy;
            CharactersRepository = charactersRepository;
            BattlesResultsStats = battlesResultsStats;
            AchievementsCollection = achievementsCollection;
        }
    }
}
