using Morpeh;

namespace Features.Enemies.View
{
    public readonly struct GameObjectComponent : IComponent
    {
        public GameObjectComponent(IGameObjectView view)
        {
            View = view;
        }
        
        public readonly IGameObjectView View;
    }
}