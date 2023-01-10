using Morpeh;

namespace Features.Enemies.View.HealthBar
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