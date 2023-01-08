using System.Text.RegularExpressions;
using Features.Enemies.View;
using Morpeh;

namespace Features.Enemies.DamageReceiving
{
    public class DeathCheckSystem : UpdateSystem
    {
        public override void OnAwake() {}

        public override void OnUpdate(float deltaTime)
        {
            var filter = World.Filter
                .With<HealthComponent>()
                .With<GameObjectComponent>();

            foreach (var entity in filter)
            {
                ref var health = ref entity.GetComponent<HealthComponent>();

                if (health.IsDead == false)
                    continue;

                ref var view = ref entity.GetComponent<GameObjectComponent>();

                view.View.DestroyObject();
                World.RemoveEntity(entity);
            }
        }
    }
}