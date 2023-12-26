using GameRules.Contracts;

namespace GameRulesTests.TestsHelpers
{
    internal class ContractsHelpers
    {
        internal static Employer CreateEmployer(int reputation)
        {
            return new Employer(reputation);
        }

        internal static IEnumerable<Contract> CreateContractsWithExpirationTurns(Employer employer, int[] expirationTurns)
        {
            foreach (int expirationTurn in expirationTurns)
            {
                yield return CreateContract(employer, expirationTurn, 0);
            }
        }

        internal static IEnumerable<Contract> CreateContractsWithWages(Employer employer, float[] wages)
        {
            foreach (float wage in wages)
            {
                yield return CreateContract(employer, 0, wage);
            }
        }

        internal static Contract CreateContract(Employer employer, int expirationTurn, float wage)
        {
            var contractable = CharactersHelpers.CreateElfCharacter(0);
            return new Contract(employer, contractable, wage, expirationTurn);
        }

        internal static void AddContractsToEmployer(Employer employer, Contract[] contracts)
        {
            foreach (var contract in contracts)
            {
                employer.AddContract(contract);
            }
        }
    }
}
