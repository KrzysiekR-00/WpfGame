using GameRules.Combat.BattleSquads;
using GameRules.Combat.Moves;

namespace GameRules.Combat
{
    public class Battle
    {
        private readonly BattleSquadMember[] _membersInMoveOrder;

        private readonly BattleSquad _squad1;
        private readonly BattleSquad _squad2;

        private readonly List<IBattleMakeableMove> _movesMade = new();

        public int CurrentRound { get; private set; }

        public BattleStatus BattleStatus { get; }

        public IBattleMakeableMove[] Moves => _movesMade.ToArray();

        public BattleSquad[] BattleSquads
        {
            get => new[] { _squad1, _squad2 };
        }

        internal Battle(BattleSquad squad1, BattleSquad squad2)
        {
            _squad1 = squad1;
            _squad2 = squad2;

            BattleStatus = new(this);

            BattleSquad.SetEnemies(squad1, squad2);

            var squadMembers = squad1.Members.Concat(squad2.Members).ToArray();
            _membersInMoveOrder = BattleSquadMembersMovesOrder.GetMovesOrder(squadMembers);

            CurrentRound = 1;
        }

        public bool TryDoNextRound(out IBattleMakeableMove[] movesMade)
        {
            List<IBattleMakeableMove> movesMadeList = new();
            if (BattleStatus.IsOver)
            {
                movesMade = movesMadeList.ToArray();
                return false;
            }

            foreach (var member in _membersInMoveOrder)
            {
                var moveMade = member.MakeMove();

                movesMadeList.Add(moveMade);
            }

            CurrentRound++;
            _movesMade.AddRange(movesMadeList);

            movesMade = movesMadeList.ToArray();
            return true;
        }
    }
}
