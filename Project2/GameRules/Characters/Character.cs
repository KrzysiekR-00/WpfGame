using GameRules.Combat.Combatables;
using GameRules.Contracts;

namespace GameRules.Characters
{
    public class Character : IContractable, ICombatable
    {
        public string Name { get; }

        public Race Race { get; }

        public int Level { get; }

        public Contract? Contract { get; private set; }
        public int ExpectedEmployerReputation => Level;

        public State State { get; set; }
        public Attributes BaseAttributes { get; }

        internal Character(string name, Race race, int level, State state, Attributes baseAttributes)
        {
            Name = name;
            Race = race;
            Level = level;
            State = state;
            BaseAttributes = baseAttributes;
        }

        public void SetContract(Contract? contract)
        {
            Contract = contract;
        }
    }
}
