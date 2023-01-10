using Features.Common.Worlds;
using Features.Enemies.DamageReceiving;
using Features.Enemies.Factory.SpawnPoints;
using Features.Enemies.View;
using Features.Enemies.View.HealthBar;
using Features.Enemies.View.Object;
using Features.Enemies.View.Transform;
using Morpeh;
using UnityEngine;

namespace Features.Enemies.Factory
{
    public class EnemyFactory
    {
        public EnemyFactory(
            IEnemiesSpawnPoints spawnPoints,
            IEntityCreator entityCreator,
            EnemiesConfig config)
        {
            _spawnPoints = spawnPoints;
            _entityCreator = entityCreator;
            _config = config;
        }
        
        private readonly IEnemiesSpawnPoints _spawnPoints;
        private readonly IEntityCreator _entityCreator;
        private readonly EnemiesConfig _config;

        public void SpawnStartup()
        {
            for (var i = 0; i < _config.AmountOnStart; i++)
                Create();
        }
        
        public void Create()
        {
            var position = _spawnPoints.GetRandom();
            var config = _config.GetRandom();

            var instance = Object.Instantiate(config.Prefab, position, Quaternion.identity);
            var entity = _entityCreator.Create();

            var health = new EnemyHealthComponent(config.Health);

            var gameObjectView = instance.GetComponent<IGameObjectView>();
            var gameObjectViewComponent = new GameObjectComponent(gameObjectView);

            var transformView = instance.GetComponent<ITransformView>();
            var transformComponent = new TransformComponent(transformView);

            var healthBarView = instance.GetComponent<IHealthBarView>();
            var healthBarComponent = new HealthBarComponent(healthBarView);
            
            entity.SetComponent(health);
            entity.SetComponent(gameObjectViewComponent);
            entity.SetComponent(transformComponent);
            entity.SetComponent(healthBarComponent);
        }
    }
}