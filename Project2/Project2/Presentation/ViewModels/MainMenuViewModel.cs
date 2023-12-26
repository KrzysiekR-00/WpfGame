using GameRules.GameLoop;
using Project2.Presentation.ViewModels.Gameplay;
using System.Reflection;
using System.Windows.Input;

namespace Project2.Presentation.ViewModels
{
    internal class MainMenuViewModel : NavigableViewModel
    {
        public string? Title { get; }
        public string? AppVersion { get; }
        public ICommand StartNewGame { get; private set; }

        internal MainMenuViewModel(Navigator navigator) : base(navigator)
        {
            var assembly = Assembly.GetExecutingAssembly().GetName();
            Title = assembly.Name;

            AppVersion = assembly.Version?.ToString();

            StartNewGame = new RelayCommand(_ => NavigateToNewGameView());
        }

        private void NavigateToNewGameView()
        {
            var newGame = GameLoopController.NewGame();
            _navigator.NavigateTo(new TurnLayoutViewModel(_navigator, newGame));
        }
    }
}
