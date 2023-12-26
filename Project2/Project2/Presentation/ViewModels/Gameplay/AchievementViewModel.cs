using GameRules.Achievements;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal readonly struct AchievementViewModel
    {
        public int Reward { get; }
        public int TurnLimit { get; }
        public string Description { get; }
        public string Status { get; }

        internal AchievementViewModel(Achievement achievement)
        {
            Reward = achievement.Reward;
            TurnLimit = achievement.TurnLimit;
            Description = achievement.Description;

            Status = achievement.Status switch
            {
                AchievementStatus.InProgress => "In progress...",
                AchievementStatus.Success => "Success",
                AchievementStatus.Failure => "Failure",
                _ => string.Empty,
            };
        }
    }
}
