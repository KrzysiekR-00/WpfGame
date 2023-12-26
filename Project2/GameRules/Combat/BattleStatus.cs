using GameRules.Combat.BattleSquads;

namespace GameRules.Combat
{
    public class BattleStatus
    {
        public const int MaxBattleRounds = 30;

        private readonly Battle _battle;

        public bool IsOver
        {
            get =>
                _battle.BattleSquads[0].IsSquadOutOfCombat() ||
                _battle.BattleSquads[1].IsSquadOutOfCombat() ||
                _battle.CurrentRound > MaxBattleRounds;
        }

        internal BattleStatus(Battle battle)
        {
            _battle = battle;
        }

        public BattleResult? GetBattleResultOrNull()
        {
            if (!IsOver) return null;

            BattleSquad? winner = null;

            if (_battle.BattleSquads[0].IsSquadOutOfCombat() && !_battle.BattleSquads[1].IsSquadOutOfCombat()) winner = _battle.BattleSquads[1];

            if (!_battle.BattleSquads[0].IsSquadOutOfCombat() && _battle.BattleSquads[1].IsSquadOutOfCombat()) winner = _battle.BattleSquads[0];

            return new BattleResult(winner);
        }
    }
}
