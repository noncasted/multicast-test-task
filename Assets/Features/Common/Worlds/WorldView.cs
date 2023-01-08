using Morpeh;

namespace Features.Common.Worlds
{
    public class WorldView : IEntityCreator
    {
        public WorldView(World world)
        {
            _world = world;
        }
        
        private readonly World _world;
        
        public Entity Create()
        {
            return _world.CreateEntity();
        }
    }
}