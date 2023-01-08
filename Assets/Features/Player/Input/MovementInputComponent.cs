using Morpeh;
using UnityEngine;

namespace Features.Player.Input
{
    public struct MovementInputComponent : IComponent
    {
        private Vector2 _input;

        public Vector2 Input => _input;

        public void OnInput(Vector2 input)
        {
            _input = input;
        }
    }
}