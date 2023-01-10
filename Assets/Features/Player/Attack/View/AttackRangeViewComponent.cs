using Morpeh;

namespace Features.Player.Attack.View
{
    public readonly struct AttackRangeViewComponent : IComponent
    {
        public AttackRangeViewComponent(IAttackRangeView rangeView)
        {
            RangeView = rangeView;
        }
        
        public readonly IAttackRangeView RangeView;
    }
}