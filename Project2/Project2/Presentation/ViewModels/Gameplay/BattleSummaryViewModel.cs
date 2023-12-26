using GameRules.Combat;
using GameRules.Combat.BattleStats;
using GameRules.GameLoop;
using System.Linq;
using System.Windows.Input;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class BattleSummaryViewModel : NavigableViewModel
    {
        private readonly GameLoopController _gameLoopController;
        private readonly BattleResult _battleResult;
        private readonly BattleStats _battleStats;

        public CharacterBattleStatsViewModel[] CharactersStats => _battleStats.CombatableStats.Select(s => new CharacterBattleStatsViewModel(s)).ToArray();
        public string SummaryMessage { get; private set; }
        public string RewardMessage { get; private set; }
        public ICommand NextTurn { get; private set; }

        internal BattleSummaryViewModel(Navigator navigator, GameLoopController gameLoopController, BattleResult battleResult, BattleStats battleStats) : base(navigator)
        {
            _gameLoopController = gameLoopController;
            _battleResult = battleResult;
            _battleStats = battleStats;

            SummaryMessage = string.Empty;
            RewardMessage = string.Empty;
            NextTurn = new RelayCommand(_ => NavigateToNextBattlePreparation());

            ShowBattleSummaryMessage(gameLoopController, battleResult);
            _gameLoopController.StartNextTurn(_battleResult);
            ShowBattleRewardMessage(gameLoopController);
        }

        private void ShowBattleSummaryMessage(GameLoopController gameLoopController, BattleResult battleResult)
        {
            if (battleResult.Winner == null)
            {
                SummaryMessage = "Undecided result";
            }
            else
            {
                if (battleResult.Winner != gameLoopController.GameState.NextEnemy)
                {
                    SummaryMessage = "Victory";
                }
                else
                {
                    SummaryMessage = "Defeat";
                }
            }
        }

        private void ShowBattleRewardMessage(GameLoopController gameLoopController)
        {
            var lastRewardOperation = gameLoopController.GameState.Team.Account.OperationsHistory.LastOrDefault(o => o.OperationType == GameRules.Finances.OperationType.BattleReward);

            RewardMessage = new OperationViewModel(lastRewardOperation).FormattedAmount;
        }

        private void NavigateToNextBattlePreparation()
        {
            _navigator.NavigateTo(new TurnLayoutViewModel(_navigator, _gameLoopController));
        }
    }
}
