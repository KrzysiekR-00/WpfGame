using GameRules.Finances;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal readonly struct OperationViewModel
    {
        public string FormattedAmount { get; }
        public float Amount { get; }
        public string Description { get; }
        public int Turn { get; }

        internal OperationViewModel(Operation operation)
        {
            Turn = operation.Turn;
            Amount = operation.Amount;

            FormattedAmount = Amount > 0 ? "+" + Amount.ToString("N2") : Amount.ToString("N2");

            Description = operation.OperationType switch
            {
                OperationType.Wages => "Payment of wages",
                OperationType.BattleReward => "Battle reward",
                OperationType.Grant => "Grant",
                OperationType.AchievementReward => "Achievement reward",
                _ => string.Empty,
            };
        }
    }
}
