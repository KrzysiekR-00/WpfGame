using GameRules.Characters;
using GameRules.Combat.BattleSquads;

namespace GameRules.GameLoop
{
    internal static class NextEnemyGenerator
    {
        internal static BattleSquad Generate(float playerTeamReputation)
        {
            int teamSize = new Random().Next(1, 4);
            BattleSquadMember[] enemies = new BattleSquadMember[teamSize];

            int enemyMinLevel = (int)Math.Round(playerTeamReputation * 0.75f);
            int enemyMaxLevel = (int)Math.Round(playerTeamReputation * 1.5f);

            for (int i = 0; i < teamSize; i++)
            {
                var enemy = RandomCharacterCreator.Create(enemyMinLevel, enemyMaxLevel);
                enemies[i] = new BattleSquadMember(enemy);
            }

            return new BattleSquad(enemies);
        }
    }
}
