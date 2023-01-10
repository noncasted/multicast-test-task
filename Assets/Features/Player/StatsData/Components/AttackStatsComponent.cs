using Features.Player.StatsData.Abstract;
using Morpeh;

namespace Features.Player.StatsData.Components
{
    public readonly struct AttackStatsComponent : IComponent
    {
        public AttackStatsComponent(IAttackStats stats)
        {
            Stats = stats;
        }
        
        public readonly IAttackStats Stats;
    }
}