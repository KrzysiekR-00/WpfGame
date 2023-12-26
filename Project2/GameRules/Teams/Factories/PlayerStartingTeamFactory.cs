using GameRules.Characters;
using GameRules.Contracts;
using GameRules.Contracts.Negotiations;

namespace GameRules.Teams.Factories
{
    internal class PlayerStartingTeamFactory : ITeamFactory
    {
        internal const int TeamReputation = 10;
        internal const int ContractsCount = 5;
        internal const int AccountBalance = 100000;
        internal const int ContractsExpirationTurn = 5;

        public Team Create()
        {
            var team = new Team(TeamReputation, AccountBalance);

            for (int i = 0; i < ContractsCount; i++)
            {
                AddNewContract(team, TeamReputation, ContractsExpirationTurn);
            }

            return team;
        }

        private static void AddNewContract(Team team, int teamReputation, int contractsExpirationTurn)
        {
            var character = RandomCharacterCreator.Create(teamReputation);
            var contract = CreateContract(team.Employer, character, contractsExpirationTurn);
            ContractsManager.AddContractToContractorAndEmployer(contract);
        }

        private static Contract CreateContract(Employer employer, Character character, int contractsExpirationTurn)
        {
            var wage = WageCalculator.GetWage(
                character.ExpectedEmployerReputation, 
                TeamReputation,
                contractsExpirationTurn
                );

            return new Contract(employer, character, wage, contractsExpirationTurn);
        }
    }
}
