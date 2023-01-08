using Features.Player.StatsData.Abstract;
using Morpeh;

namespace Features.Player.StatsData.Components
{
    public readonly struct MovementStatsComponent : IComponent
    {
        public MovementStatsComponent(IMovementStats stats)
        {
            _stats = stats;
        }
        
        private readonly IMovementStats _stats;

        public float Speed => _stats.Speed;
    }
}