namespace GameRules.Combat.Combatables
{
    public readonly struct Attributes
    {
        public int Stamina { get; }
        public int Damage { get; }
        public int Armor { get; }
        public int Initiative { get; }

        internal Attributes(int stamina, int damage, int armor, int initiative)
        {
            Stamina = stamina;
            Damage = damage;
            Armor = armor;
            Initiative = initiative;
        }
    }
}
