using GameRules.Characters;
using GameRules.Combat;
using GameRules.Combat.BattleStats;
using GameRules.Combat.Moves;
using GameRules.GameLoop;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Battle = GameRules.Combat.Battle;

namespace Project2.Presentation.ViewModels.Gameplay
{
    internal class BattleViewModel : NavigableViewModel
    {
        private readonly GameLoopController _gameLoopController;
        private readonly Battle _battle;

        private BattleResult? _battleResult = null;

        private readonly StringBuilder _battleLog = new();
        private bool _isBattleOver = false;

        private TimeSpan _nextRoundDelay = TimeSpan.FromSeconds(0.5);

        public ICommand SimulateBattleToEnd { get; private set; }
        public ICommand Continue { get; private set; }

        public string BattleLog
        {
            get
            {
                lock (_battleLog)
                {
                    return _battleLog.ToString();
                }
            }
        }

        public bool IsBattleOver
        {
            get => _isBattleOver;
            private set
            {
                _isBattleOver = value;
                OnPropertyChanged(nameof(IsBattleOver));
            }
        }

        public CharacterViewModel[] PlayerSquad => _battle.BattleSquads[0].Members
            .Select(m => m.Combatable).OfType<Character>()
            .Select(c => new CharacterViewModel(c)).ToArray();

        public CharacterViewModel[] EnemySquad => _battle.BattleSquads[1].Members
            .Select(m => m.Combatable).OfType<Character>()
            .Select(c => new CharacterViewModel(c)).ToArray();

        internal BattleViewModel(Navigator navigator, GameLoopController gameLoopController, Battle battle) : base(navigator)
        {
            _gameLoopController = gameLoopController;
            _battle = battle;

            SimulateBattleToEnd = new RelayCommand(_ => _nextRoundDelay = TimeSpan.FromSeconds(0.1));
            Continue = new RelayCommand(_ => NavigateToBattleSummaryView());

            WriteLineInBattleLog("The battle has begun");

            Thread battleThread = new(new ThreadStart(BattleRoundsLoop));
            battleThread.Start();
        }

        private void BattleRoundsLoop()
        {
            while (!_battle.BattleStatus.IsOver)
            {
                Thread.Sleep((int)_nextRoundDelay.TotalMilliseconds);

                DoNextBattleRoundAndWriteLogs();

                OnPropertyChanged(nameof(BattleLog));
            }
        }

        private void WriteLineInBattleLog(string line)
        {
            lock (_battleLog)
            {
                _battleLog.AppendLine(line);
            }
        }

        private void DoNextBattleRoundAndWriteLogs()
        {
            WriteLineInBattleLog("Round " + _battle.CurrentRound + "/" + BattleStatus.MaxBattleRounds);

            if (_battle.TryDoNextRound(out var moves))
            {
                OnPropertyChanged(nameof(PlayerSquad));
                OnPropertyChanged(nameof(EnemySquad));

                WriteMovesLogs(moves);
            }

            if (_battle.BattleStatus.IsOver)
            {
                _battleResult = _battle.BattleStatus.GetBattleResultOrNull();

                IsBattleOver = true;

                WriteLineInBattleLog("Battle is over");
            }
        }

        private void WriteMovesLogs(IBattleMakeableMove[] moves)
        {
            int i = 1;
            foreach (var move in moves)
            {
                WriteMoveLog(move, i++);
            }
        }

        private void WriteMoveLog(IBattleMakeableMove move, int moveNumber)
        {
            string moveLog = moveNumber.ToString() + ". " + ((Character)move.Combatable).Name;
            moveLog += " - ";

            if (move is AggressiveMove aggressiveMove)
            {
                moveLog += string.Format(
                    "Aggressive move on {0}. Damage caused: {1}.",
                    ((Character)aggressiveMove.Target).Name,
                    aggressiveMove.Damage.ToString("N1")
                    );
            }

            if (move is PassMove)
            {
                moveLog += "Pass";
            }

            WriteLineInBattleLog(moveLog);
        }

        private void NavigateToBattleSummaryView()
        {
            if (_battleResult.HasValue)
            {
                var battleStats = new BattleStats(PlayerSquad.Select(p => p.Character).ToArray(), _battle.Moves);
                _navigator.NavigateTo(new BattleSummaryViewModel(_navigator, _gameLoopController, _battleResult.Value, battleStats));
            }
        }
    }
}
