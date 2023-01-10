using Features.Player.Input;
using Features.Player.Movement.View;
using Features.Player.StatsData.Components;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Features.Player.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MovementSystem), fileName = "MovementSystem")]
    public class MovementSystem : FixedUpdateSystem
    {
        public override void OnAwake() {}

        public override void OnUpdate(float deltaTime)
        {
            var filter = World.Filter
                .With<RigidBodyComponent>()
                .With<MovementStatsComponent>()
                .With<MovementInputComponent>();

            foreach (var entity in filter)
            {
                ref var rigidBody = ref entity.GetComponent<RigidBodyComponent>();
                ref var stats = ref entity.GetComponent<MovementStatsComponent>();
                ref var input = ref entity.GetComponent<MovementInputComponent>();

                var direction = new Vector3(input.Input.x, 0f, input.Input.y);

                rigidBody.View.Move(direction * stats.Speed);
            }
        }
    }
}