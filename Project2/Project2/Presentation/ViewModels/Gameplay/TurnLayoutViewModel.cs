using GameRules.GameLoop;
using System.Windows.Input;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class TurnLayoutViewModel : NavigableViewModel
    {
        private readonly Navigator _frameNavigator = new();

        private ViewModelBase? _frameCurrentViewModel;

        public GameLoopController GameLoopController { get; }

        public ViewModelBase? FrameCurrentViewModel
        {
            get => _frameCurrentViewModel;
            private set
            {
                _frameCurrentViewModel = value;
                OnPropertyChanged(nameof(FrameCurrentViewModel));
            }
        }

        public ICommand Crew { get; }
        public ICommand UnemployedList { get; }
        public ICommand Finances { get; }
        public ICommand Achievements { get; }
        public ICommand PrepareBattle { get; }

        internal TurnLayoutViewModel(Navigator navigator, GameLoopController gameLoopController) : base(navigator)
        {
            GameLoopController = gameLoopController;

            _frameNavigator.CurrentViewModelChanged += () => { FrameCurrentViewModel = _frameNavigator.CurrentViewModel; };

            NavigateToEmployerOverviewView();

            Crew = new RelayCommand(_ => NavigateToEmployerOverviewView());
            UnemployedList = new RelayCommand(_ => NavigateToUnemployedListView());
            Finances = new RelayCommand(_ => NavigateToFinancesOverviewView());
            Achievements = new RelayCommand(_ => NavigateToAchievementsView());
            PrepareBattle = new RelayCommand(_ => NavigateToPrepareBattleView());
        }

        private void NavigateToEmployerOverviewView()
        {
            _frameNavigator.NavigateTo(new EmployerOverviewViewModel(_frameNavigator, GameLoopController));
        }

        private void NavigateToUnemployedListView()
        {
            _frameNavigator.NavigateTo(new UnemployedListViewModel(_frameNavigator, GameLoopController));
        }

        private void NavigateToFinancesOverviewView()
        {
            _frameNavigator.NavigateTo(new FinancesOverviewViewModel(GameLoopController.GameState.Team.Account));
        }

        private void NavigateToAchievementsView()
        {
            _frameNavigator.NavigateTo(new AchievementsViewModel(GameLoopController.GameState));
        }

        private void NavigateToPrepareBattleView()
        {
            _frameNavigator.NavigateTo(new PrepareBattleViewModel(_navigator, GameLoopController));
        }
    }
}
