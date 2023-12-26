namespace GameRules.Combat.Combatables
{
    public interface ICombatable
    {
        public State State { get; set; }

        public Attributes BaseAttributes { get; }
    }
}
