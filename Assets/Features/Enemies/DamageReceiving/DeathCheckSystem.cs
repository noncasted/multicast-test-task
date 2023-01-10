using Features.Enemies.Factory;
using Features.Enemies.View;
using Morpeh;
using UniRx;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Features.Enemies.DamageReceiving
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/EnemyDeathCheck", fileName = "EnemyDeathCheck")]
    public class DeathCheckSystem : UpdateSystem
    {
        public void Construct(EnemyFactory factory)
        {
            _factory = factory;
        }
        
        private EnemyFactory _factory;
        
        public override void OnAwake() {}

        public override void OnUpdate(float deltaTime)
        {
            var filter = World.Filter
                .With<EnemyHealthComponent>()
                .With<GameObjectComponent>();

            foreach (var entity in filter)
            {
                ref var health = ref entity.GetComponent<EnemyHealthComponent>();

                if (health.IsDead == false)
                    continue;

                ref var view = ref entity.GetComponent<GameObjectComponent>();

                view.View.DestroyObject();
                World.RemoveEntity(entity);

                _factory.Create();
            }
        }
    }
}