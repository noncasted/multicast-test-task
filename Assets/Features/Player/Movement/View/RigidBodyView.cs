using UnityEngine;

namespace Features.Player.Movement.View
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public class RigidBodyView : MonoBehaviour, IRigidBodyView
    {
        private Rigidbody _rigidbody;

        public Vector3 Position => _rigidbody.position;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
        }
    }
}