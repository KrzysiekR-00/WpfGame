using GameRules.GameLoop;
using System.Linq;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class AchievementsViewModel : ViewModelBase
    {
        public GameState GameState { get; }

        public AchievementViewModel[] Achievements { get; }

        internal AchievementsViewModel(GameState gameState)
        {
            GameState = gameState;

            Achievements = gameState.AchievementsCollection.Achievements.OrderBy(a => a.TurnLimit).Select(a => new AchievementViewModel(a)).ToArray();
        }
    }
}
