namespace GameRules.Combat.Combatables
{
    public class State
    {
        private float _energy = 100;
        private float _health = 100;

        public float Energy
        {
            get => _energy;
            internal set
            {
                _energy = value;
                _energy = Math.Max(_energy, 0);
                _energy = Math.Min(_energy, 100);
            }
        }

        public float Health
        {
            get => _health;
            internal set
            {
                _health = value;
                _health = Math.Max(_health, 0);
                _health = Math.Min(_health, 100);
            }
        }

        internal int? InjuryExpirationTurn { get; set; }
    }
}
