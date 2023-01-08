using Morpeh;
using UnityEngine;

namespace Features.Common.Worlds
{
    [DisallowMultipleComponent]
    public class WorldHandler : MonoBehaviour
    {
        private World _world;

        public void Construct(World world)
        {
            _world = world;
        }

        private void Update()
        {
            _world?.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _world?.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}