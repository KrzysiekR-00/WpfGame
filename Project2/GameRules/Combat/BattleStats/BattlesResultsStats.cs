using GameRules.Combat.BattleSquads;

namespace GameRules.Combat.BattleStats
{
    public class BattlesResultsStats
    {
        public int Victories { get; internal set; }
        public int Undecided { get; internal set; }
        public int Defeats { get; internal set; }
        public int TotalBattles => Victories + Undecided + Defeats;
        public float PercentageVictories => TotalBattles == 0 ? 0 : (float)Victories / TotalBattles * 100;

        internal void RegisterResult(BattleResult battleResult, BattleSquad enemy)
        {
            if (battleResult.Winner == null) Undecided++;
            else
            {
                if (battleResult.Winner != enemy) Victories++;
                else Defeats++;
            }
        }
    }
}
