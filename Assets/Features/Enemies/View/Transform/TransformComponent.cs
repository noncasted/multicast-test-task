using Morpeh;

namespace Features.Enemies.View.Transform
{       
    public readonly struct TransformComponent : IComponent
    {
        public TransformComponent(ITransformView view)
        {
            View = view;
        }
        
        public readonly ITransformView View;
    }
}       