using UnityEngine;

namespace Features.Player.Movement.View
{
    public interface IRigidBodyView
    {
        Vector3 Position { get; }
        
        void Move(Vector3 position);
    }
}