using GameRules.Characters;
using GameRules.GameLoop;
using GameRules.Teams;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class PrepareBattleViewModel : NavigableViewModel
    {
        private readonly GameLoopController _gameLoopController;

        private CharacterViewModel? _selectedCharacter;
        private CharacterViewModel? _selectedAvaibleCharacter;
        private CharacterViewModel? _selectedBattleSquadCharacter;
        private bool _isBattleReady;
        private bool _selectedCharacterIsInBattleSquad;
        private bool _selectedCharacterIsNotInBattleSquad;

        public static int ProperNumberOfMembersInSquad => PlayerBattleSquad.NumberOfMembersInSquad;

        public ObservableCollection<CharacterViewModel> AvaibleCharacters { get; private set; }
        public ObservableCollection<CharacterViewModel> BattleSquadCharacters { get; private set; }

        public CharacterViewModel? SelectedAvaibleCharacter
        {
            get { return _selectedAvaibleCharacter; }
            set
            {
                _selectedAvaibleCharacter = value;
                OnPropertyChanged(nameof(SelectedAvaibleCharacter));
            }
        }

        public CharacterViewModel? SelectedBattleSquadCharacter
        {
            get { return _selectedBattleSquadCharacter; }
            set
            {
                _selectedBattleSquadCharacter = value;
                OnPropertyChanged(nameof(SelectedBattleSquadCharacter));
            }
        }

        public CharacterViewModel? SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
            }
        }

        public bool SelectedCharacterIsInBattleSquad
        {
            get => _selectedCharacterIsInBattleSquad;
            private set
            {
                _selectedCharacterIsInBattleSquad = value;
                OnPropertyChanged(nameof(SelectedCharacterIsInBattleSquad));
            }
        }

        public bool SelectedCharacterIsNotInBattleSquad
        {
            get => _selectedCharacterIsNotInBattleSquad;
            private set
            {
                _selectedCharacterIsNotInBattleSquad = value;
                OnPropertyChanged(nameof(SelectedCharacterIsNotInBattleSquad));
            }
        }

        public bool IsBattleReady
        {
            get => _isBattleReady;
            private set
            {
                _isBattleReady = value;
                OnPropertyChanged(nameof(IsBattleReady));
            }
        }

        public CharacterViewModel[] EnemySquad => _gameLoopController.GameState.NextEnemy.Members.Select(m => m.Combatable).OfType<Character>().Select(c => new CharacterViewModel(c)).ToArray();

        public ICommand StartBattle { get; private set; }
        public ICommand MoveSelectedCharacterToBattleSquad { get; private set; }
        public ICommand MoveSelectedCharacterOutOfBattleSquad { get; private set; }

        internal PrepareBattleViewModel(Navigator navigator, GameLoopController gameLoopController) : base(navigator)
        {
            _gameLoopController = gameLoopController;

            StartBattle = new RelayCommand(_ => NavigateToBattleView());
            MoveSelectedCharacterToBattleSquad = new RelayCommand(_ => MoveCharacterToBattleSquad(SelectedCharacter));
            MoveSelectedCharacterOutOfBattleSquad = new RelayCommand(_ => MoveCharacterOutOfBattleSquad(SelectedCharacter));

            AvaibleCharacters = new(_gameLoopController.GameState.Team.Crew.Select(c => new CharacterViewModel(c, gameLoopController.GameState.Turn)));
            BattleSquadCharacters = new();

            PropertyChanged += ViewModelPropertyChanged;

            SelectedAvaibleCharacter = AvaibleCharacters.FirstOrDefault();
        }

        private void ViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SelectedAvaibleCharacter):
                    if (SelectedAvaibleCharacter != null)
                    {
                        SelectedBattleSquadCharacter = null;
                        SelectedCharacter = SelectedAvaibleCharacter;
                    }
                    break;

                case nameof(SelectedBattleSquadCharacter):
                    if (SelectedBattleSquadCharacter != null)
                    {
                        SelectedAvaibleCharacter = null;
                        SelectedCharacter = SelectedBattleSquadCharacter;
                    }
                    break;

                case nameof(SelectedCharacter):
                    SelectedCharacterIsInBattleSquad = SelectedCharacter != null && BattleSquadCharacters.Contains(SelectedCharacter);
                    SelectedCharacterIsNotInBattleSquad = SelectedCharacter != null && !BattleSquadCharacters.Contains(SelectedCharacter);
                    break;
            }
        }

        private void NavigateToBattleView()
        {
            var selectedCharacters = BattleSquadCharacters.Select(c => c.Character).ToArray();

            var playerBattleSquad = PlayerBattleSquad.Create(selectedCharacters[0], selectedCharacters[1], selectedCharacters[2]);
            var battle = _gameLoopController.StartBattle(playerBattleSquad);
            _navigator.NavigateTo(new BattleViewModel(_navigator, _gameLoopController, battle));
        }

        private void MoveCharacterToBattleSquad(CharacterViewModel? character)
        {
            if (character == null) return;
            if (BattleSquadCharacters.Count >= ProperNumberOfMembersInSquad) return;

            AvaibleCharacters.Remove(character);
            BattleSquadCharacters.Add(character);

            SelectedBattleSquadCharacter = character;

            Validate();
        }

        private void MoveCharacterOutOfBattleSquad(CharacterViewModel? character)
        {
            if (character == null) return;

            BattleSquadCharacters.Remove(character);
            AvaibleCharacters.Add(character);

            SelectedAvaibleCharacter = character;

            Validate();
        }

        private void Validate()
        {
            IsBattleReady = BattleSquadCharacters.Count == ProperNumberOfMembersInSquad;
        }
    }
}
