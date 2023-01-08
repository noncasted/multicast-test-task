using Morpeh;
using UnityEngine;

namespace Features.Player.Movement.View
{
    public readonly struct RigidBodyComponent : IComponent
    {
        public RigidBodyComponent(IRigidBodyView view)
        {
            View = view;
        }
        
        public readonly IRigidBodyView View;
    }
}