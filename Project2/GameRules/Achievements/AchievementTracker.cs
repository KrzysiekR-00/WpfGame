using GameRules.GameLoop;

namespace GameRules.Achievements
{
    internal static class AchievementTracker
    {
        internal static IEnumerable<Achievement> VerifyAndGetNewAchievements(AchievementsCollection achievementsCollection, GameState gameState)
        {
            foreach (var achievement in achievementsCollection.Achievements)
            {
                if (VerifyAchievementAndUpdateStatus(achievement, gameState)) yield return achievement;
            }
        }

        private static bool VerifyAchievementAndUpdateStatus(Achievement achievement, GameState gameState)
        {
            if (achievement.Status == AchievementStatus.InProgress && gameState.Turn <= achievement.TurnLimit)
            {
                if (achievement.Predicate(gameState))
                {
                    achievement.Status = AchievementStatus.Success;
                    return true;
                }
                else
                {
                    if (gameState.Turn == achievement.TurnLimit) achievement.Status = AchievementStatus.Failure;
                }
            }

            return false;
        }
    }
}
