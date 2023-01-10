using Morpeh;

namespace Features.Enemies.View
{
    public readonly struct HealthBarComponent : IComponent
    {
        public HealthBarComponent(IHealthBarView view)
        {
            View = view;
        }
        
        public readonly IHealthBarView View;
    }
}