using GameRules.Characters;
using GameRules.Contracts;
using GameRules.Contracts.Negotiations;
using System.Windows.Input;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class ContractNegotiationViewModel : NavigableViewModel
    {
        private int _proposalLength;
        private float _expectedWage;

        public CharacterViewModel? Character { get; }
        public ContractNegotiation ContractNegotiation { get; }

        public int ProposalLength
        {
            get => _proposalLength;
            set
            {
                _proposalLength = value;
                OnPropertyChanged(nameof(ProposalLength));
            }
        }

        public float ExpectedWage
        {
            get => _expectedWage;
            set
            {
                _expectedWage = value;
                OnPropertyChanged(nameof(ExpectedWage));
            }
        }

        public ICommand WalkAway => new RelayCommand(_ => NavigateToPreviousViewModel());
        public ICommand Sign => new RelayCommand(_ => SignContract());

        internal ContractNegotiationViewModel(Navigator navigator, Character character, Employer employer, int currentTurn)
            : base(navigator)
        {
            if (character.Contract != null)
            {
                throw new System.Exception("Character already has contract");
            }

            PropertyChanged += ViewModelPropertyChanged;
            Character = new CharacterViewModel(character, currentTurn);
            ContractNegotiation = new NewContractNegotiation(employer, character, currentTurn);
            ProposalLength = ContractNegotiation.MinContractLength + 4;
        }

        internal ContractNegotiationViewModel(Navigator navigator, Contract contractToExtend, int currentTurn)
            : base(navigator)
        {
            if (contractToExtend.Contractor is Character character)
            {
                Character = new CharacterViewModel(character, currentTurn);
            }

            PropertyChanged += ViewModelPropertyChanged;
            ContractNegotiation = new ExtensionNegotiation(contractToExtend, currentTurn);
            ProposalLength = ContractNegotiation.MinContractLength + 3;
        }

        private void ViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ProposalLength):
                    ExpectedWage = ContractNegotiation.GetContractableExpectedWage(ProposalLength);
                    break;
            }
        }

        private void NavigateToPreviousViewModel()
        {
            if (_navigator.PreviousViewModel != null)
            {
                _navigator.NavigateTo(_navigator.PreviousViewModel);
            }
        }

        private void SignContract()
        {
            ContractNegotiation.SignContract(ProposalLength);

            NavigateToPreviousViewModel();
        }
    }
}
