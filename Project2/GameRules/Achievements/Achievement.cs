using GameRules.GameLoop;

namespace GameRules.Achievements
{
    public class Achievement
    {
        public int Reward { get; }
        public int TurnLimit { get; }
        public string Description { get; }

        public AchievementStatus Status { get; internal set; }

        internal Predicate<GameState> Predicate { get; }

        internal Achievement(int reward, int turnLimit, string description, Predicate<GameState> predicate)
        {
            Reward = reward;
            TurnLimit = turnLimit;
            Description = description;
            Predicate = predicate;

            Status = AchievementStatus.InProgress;
        }
    }
}
