using GameRules.Characters;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class CharacterViewModel : ViewModelBase
    {
        public Character Character { get; }

        public int? ContractsTurnsLeft { get; }

        internal CharacterViewModel(Character character, int? currentTurn = null)
        {
            Character = character;

            if (currentTurn.HasValue && Character.Contract != null) ContractsTurnsLeft = Character.Contract.ExpirationTurn - currentTurn;
        }
    }
}
