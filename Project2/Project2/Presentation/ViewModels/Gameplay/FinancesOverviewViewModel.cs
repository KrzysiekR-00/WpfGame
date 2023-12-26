using GameRules.Finances;
using System.Linq;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class FinancesOverviewViewModel : ViewModelBase
    {
        public OperationViewModel[] Operations { get; }

        public float Balance { get; }

        internal FinancesOverviewViewModel(Account account)
        {
            Operations = account.OperationsHistory.Select(o => new OperationViewModel(o)).OrderByDescending(o => o.Turn).ToArray();

            Balance = account.Balance;
        }
    }
}
