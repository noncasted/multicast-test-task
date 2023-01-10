using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Player.Input
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InputSystem), fileName = "InputSystem")]
    public class InputSystem : UpdateSystem
    {
        private PlayerInput _input;

        private Vector2 _movement;

        public override void OnAwake()
        {
            _input = new PlayerInput();
            _input.Enable();

            _input.Game.Movement.performed += OnMovementPerformed;
            _input.Game.Movement.canceled += OnMovementCanceled;
        }
        
        public override void Dispose()
        {
            _input.Disable();

            _input.Game.Movement.performed -= OnMovementPerformed;
            _input.Game.Movement.canceled -= OnMovementCanceled;
        }

        public override void OnUpdate(float deltaTime)
        {
            var filter = World.Filter.With<MovementInputComponent>();

            foreach (var entity in filter)
            {
                ref var inputMovable = ref entity.GetComponent<MovementInputComponent>();
                inputMovable.OnInput(_movement);
            }
        }
        
        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();

            _movement = value;
        }

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            _movement = context.ReadValue<Vector2>();
        }
    }
}