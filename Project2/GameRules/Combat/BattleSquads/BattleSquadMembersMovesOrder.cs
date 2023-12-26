namespace GameRules.Combat.BattleSquads
{
    internal static class BattleSquadMembersMovesOrder
    {
        internal static BattleSquadMember[] GetMovesOrder(BattleSquadMember[] members)
        {
            return members.OrderByDescending(m => m.Combatable.BaseAttributes.Initiative).ToArray();
        }
    }
}
