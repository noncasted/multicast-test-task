using Features.Enemies.View;
using Features.Enemies.View.HealthBar;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Features.Enemies.DamageReceiving
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/HealthViewUpdate", fileName = "HealthViewUpdate")]
    public class HealthViewUpdateSystem : UpdateSystem
    {
        public override void OnAwake() {}

        public override void OnUpdate(float deltaTime)
        {
            var filter = World.Filter
                .With<EnemyHealthComponent>()
                .With<HealthBarComponent>();

            foreach (var entity in filter)
            {
                ref var health = ref entity.GetComponent<EnemyHealthComponent>();
                ref var view = ref entity.GetComponent<HealthBarComponent>();

                view.View.SetNormalizedHealth(health.Normalized);
            }
        }
    }
}