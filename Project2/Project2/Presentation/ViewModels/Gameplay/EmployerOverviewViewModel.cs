using GameRules.Characters;
using GameRules.GameLoop;
using System.Linq;
using System.Windows.Input;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class EmployerOverviewViewModel : NavigableViewModel
    {
        private readonly GameLoopController _gameLoopController;

        private CharacterViewModel? _selectedCharacter;

        public CharacterViewModel[] Crew { get; private set; }

        public CharacterViewModel? SelectedCharacter
        {
            get
            {
                return _selectedCharacter;
            }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
            }
        }

        public ICommand ExtendContract { get; }

        internal EmployerOverviewViewModel(Navigator navigator, GameLoopController gameLoopController) : base(navigator)
        {
            _gameLoopController = gameLoopController;

            ExtendContract = new RelayCommand(_ => NavigateToContractNegotiation());

            _navigator.CurrentViewModelChanged += () =>
            {
                if (_navigator.CurrentViewModel == this)
                {
                    LoadCrew();
                }
            };

            LoadCrew();
        }

        private void LoadCrew()
        {
            var characters = _gameLoopController.GameState.Team.Employer.Contracts.Select(c => c.Contractor).OfType<Character>();
            Crew = characters.Select(c => new CharacterViewModel(c, _gameLoopController.GameState.Turn)).ToArray();

            SelectedCharacter = Crew.FirstOrDefault();
        }

        private void NavigateToContractNegotiation()
        {
            if (SelectedCharacter == null) return;
            if (SelectedCharacter.Character.Contract == null) return;

            _navigator.NavigateTo(new ContractNegotiationViewModel(
                _navigator,
                SelectedCharacter.Character.Contract,
                _gameLoopController.GameState.Turn
                ));
        }
    }
}
