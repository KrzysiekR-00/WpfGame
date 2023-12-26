using GameRules.Combat.Combatables;
using GameRules.Combat.Moves;

namespace GameRules.Combat.BattleSquads
{
    public class BattleSquadMember
    {
        public ICombatable Combatable { get; }

        private BattleSquad? _squad;

        internal bool IsOutOfCombat
        {
            get => Combatable.State.Health <= 0;
        }

        internal BattleSquadMember(ICombatable combatable)
        {
            Combatable = combatable;
        }

        internal void SetSquad(BattleSquad squad)
        {
            _squad = squad;
        }

        internal IBattleMakeableMove MakeMove()
        {
            var move = GetMove();
            move.Make();
            return move;
        }

        private IBattleMakeableMove GetMove()
        {
            if (_squad == null) return new PassMove(Combatable);
            if (_squad.Enemy == null) return new PassMove(Combatable);
            if (_squad.Enemy.Members == null || _squad.Enemy.Members.Length <= 0) return new PassMove(Combatable);
            if (IsOutOfCombat) return new PassMove(Combatable);

            var targetsInCombat = _squad.Enemy.Members.Where(t => !t.IsOutOfCombat).ToArray();
            if (targetsInCombat.Length <= 0) return new PassMove(Combatable);

            return CombatAI.GetBestAggresiveMove(this, targetsInCombat);
        }
    }
}
