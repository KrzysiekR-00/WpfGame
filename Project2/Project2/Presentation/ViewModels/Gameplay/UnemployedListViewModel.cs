using GameRules.GameLoop;
using System.Linq;
using System.Windows.Input;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class UnemployedListViewModel : NavigableViewModel
    {
        private readonly GameLoopController _gameLoopController;

        private CharacterViewModel? _selectedCharacter;

        public CharacterViewModel[] UnemployedCharacters { get; private set; }

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

        public ICommand ProposeContract { get; }

        internal UnemployedListViewModel(Navigator navigator, GameLoopController gameLoopController) : base(navigator)
        {
            _gameLoopController = gameLoopController;

            ProposeContract = new RelayCommand(_ => NavigateToContractNegotiation());

            _navigator.CurrentViewModelChanged += () =>
            {
                if (_navigator.CurrentViewModel == this)
                {
                    LoadCharacters();
                }
            };

            LoadCharacters();
        }

        private void LoadCharacters()
        {
            UnemployedCharacters = _gameLoopController.GameState.CharactersRepository.Unemployed.Select(c => new CharacterViewModel(c)).ToArray();

            SelectedCharacter = UnemployedCharacters.FirstOrDefault();
        }

        private void NavigateToContractNegotiation()
        {
            if (SelectedCharacter == null) return;

            _navigator.NavigateTo(new ContractNegotiationViewModel(
                _navigator,
                SelectedCharacter.Character,
                _gameLoopController.GameState.Team.Employer,
                _gameLoopController.GameState.Turn
                ));
        }
    }
}
