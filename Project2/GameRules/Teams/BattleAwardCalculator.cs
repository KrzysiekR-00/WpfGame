using GameRules.Characters;
using GameRules.Combat;
using GameRules.Combat.BattleSquads;

namespace GameRules.Teams
{
    internal static class BattleAwardCalculator
    {
        private const int AwardForUndecidedResult = 0;
        private const int AwardForVictory = 7500;
        private const int AwardForDefeat = 0;

        internal static float GetAwardForTeam(BattleResult battleResult, BattleSquad enemy)
        {
            float enemyLevelModifier = GetEnemyLevel(enemy);

            if (battleResult.Winner == null) return AwardForUndecidedResult * enemyLevelModifier;

            if (battleResult.Winner == enemy) return AwardForDefeat * enemyLevelModifier;

            return AwardForVictory * enemyLevelModifier;
        }

        private static int GetEnemyLevel(BattleSquad enemy)
        {
            var enemyCharacters = enemy.Members.Select(m => m.Combatable).OfType<Character>().ToArray();
            if (enemyCharacters.Length > 0) return enemyCharacters.Sum(c => c.Level);
            else return 0;
        }
    }
}
