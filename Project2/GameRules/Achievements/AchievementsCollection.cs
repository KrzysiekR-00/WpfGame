namespace GameRules.Achievements
{
    public class AchievementsCollection
    {
        public Achievement[] Achievements { get; }

        internal AchievementsCollection()
        {
            Achievements = new[]
            {
                new Achievement(
                    15000, 
                    3, 
                    "1 victory in battle until end of turn 3", 
                    (gs) => { return gs.BattlesResultsStats.Victories >= 1; } 
                    ),
                new Achievement(
                    20000, 
                    5, 
                    "At least 50% victory rate, after 5 battles", 
                    (gs) => { return gs.BattlesResultsStats.PercentageVictories >= 50 && gs.Turn == 5; } 
                    ),
                new Achievement(
                    25000,
                    7,
                    "Maximum 3 defeats, after 7 battles",
                    (gs) => { return gs.BattlesResultsStats.Defeats <= 3 && gs.Turn == 7; }
                    ),
                new Achievement(
                    30000, 
                    10,
                    "Balance 300 000 until end of turn 10", 
                    (gs) => { return gs.Team.Account.Balance == 300000; } 
                    ),
                new Achievement(
                    35000, 
                    15,
                    "8 victories until end of turn 15", 
                    (gs) => { return gs.BattlesResultsStats.Victories >= 8; } 
                    ),
                new Achievement(
                    40000,
                    20,
                    "Reputation 15 until end of turn 20",
                    (gs) => { return gs.Team.Employer.Reputation >= 15; }
                    ),
            };
        }
    }
}
