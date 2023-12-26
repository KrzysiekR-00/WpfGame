using GameRules.Achievements;
using GameRules.Characters;
using GameRules.Contracts;
using GameRules.Finances;

namespace GameRules.Teams
{
    public class Team
    {
        public Character[] Crew => Employer.Contracts.Select(c => c.Contractor).OfType<Character>().ToArray();

        public Account Account { get; }

        public Employer Employer { get; }

        internal Team(int reputation, float accountStartBalance)
        {
            Employer = new Employer(reputation);
            Account = new Account();

            Account.AddOperation(new Operation(OperationType.Grant, 0, accountStartBalance));
        }

        internal void PayWages(int currentTurn)
        {
            var wages = Employer.TotalWagesPerTurn;
            var operation = new Operation(OperationType.Wages, currentTurn, -wages);
            Account.AddOperation(operation);
        }

        internal void EarnBattleReward(int currentTurn, float amount)
        {
            var operation = new Operation(OperationType.BattleReward, currentTurn, amount);
            Account.AddOperation(operation);
        }

        internal void EarnAchievementReward(int currentTurn, Achievement achievement)
        {
            var operation = new Operation(OperationType.AchievementReward, currentTurn, achievement.Reward);
            Account.AddOperation(operation);
        }
    }
}
