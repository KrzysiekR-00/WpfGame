using GameRules.Characters;
using GameRules.Combat.BattleStats;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class CharacterBattleStatsViewModel : ViewModelBase
    {
        public Character Character { get; }
        public CombatableBattleStats Stats { get; }

        internal CharacterBattleStatsViewModel(CombatableBattleStats stats)
        {
            Character = stats.Combatable as Character;
            Stats = stats;
        }
    }
}
