using System.Reflection;

namespace Project2.Presentation.ViewModels
{
    internal class MainWindowViewModel : NavigableViewModel
    {
        private ViewModelBase? _currentViewModel;

        public string Title { get; }

        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        internal MainWindowViewModel(Navigator navigator) : base(navigator)
        {
            var assembly = Assembly.GetExecutingAssembly().GetName();
            Title = string.Format("{0} {1}", "Space Mercenaries Manager", assembly.Version?.ToString());

            _navigator.CurrentViewModelChanged += () => { CurrentViewModel = _navigator.CurrentViewModel; };

            _navigator.NavigateTo(new MainMenuViewModel(_navigator));
        }
    }
}
