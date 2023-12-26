using GameRules.Contracts;
using GameRules.Teams;

namespace GameRulesTests.TestsHelpers
{
    internal static class TeamsHelpers
    {
        internal static Team CreateTeam(int reputation)
        {
            return new Team(reputation, 0);
        }

        internal static void AddContractsToTeam(Team team, int contractsCount)
        {
            var contracts = CreateContracts(team.Employer, contractsCount);

            foreach (var contract in contracts)
            {
                team.Employer.AddContract(contract);
            }
        }

        private static IEnumerable<Contract> CreateContracts(Employer employer, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var contractable = CharactersHelpers.CreateElfCharacter(0);
                yield return new Contract(employer, contractable, 0, 0);
            }
        }
    }
}
