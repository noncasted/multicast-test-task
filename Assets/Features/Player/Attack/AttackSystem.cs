using System.Collections.Generic;
using Features.Enemies.DamageReceiving;
using Features.Enemies.View;
using Features.Player.Movement.View;
using Features.Player.StatsData.Components;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Features.Player.Attack
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/PlayerAttack", fileName = "PlayerAttack")]
    public class AttackSystem : FixedUpdateSystem
    {
        private int _maxTargets;
        private KillStats _stats;

        public void Construct(int maxTargets)
        {
            _maxTargets = maxTargets;
            _stats = new();
        }
        
        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            var playerFilter = World.Filter
                .With<AttackStatsComponent>()
                .With<RigidBodyComponent>();

            foreach (var player in playerFilter)
            {
                ref var statsComponent = ref player.GetComponent<AttackStatsComponent>();
                var stats = statsComponent.Stats;

                ref var rigidBodyComponent = ref player.GetComponent<RigidBodyComponent>();
                var playerPosition = rigidBodyComponent.View.Position;

                var enemyFilter = World.Filter
                    .With<EnemyHealthComponent>()
                    .With<TransformComponent>();

                var enemies = GetNearestEnemies(enemyFilter, playerPosition);

                var targetsDamaged = 0;
                
                foreach (var enemy in enemies)
                {
                    if (targetsDamaged == _maxTargets)
                        return;
                    
                    ref var transformComponent = ref enemy.GetComponent<TransformComponent>();
                    var enemyTransform = transformComponent.View;

                    ref var health = ref enemy.GetComponent<EnemyHealthComponent>();

                    var distance = Vector3.Distance(playerPosition, enemyTransform.Position);

                    if (distance > stats.AttackRadius)
                        continue;
                    
                    health.OnDamage(stats.DamagePerSecond * deltaTime);
                    
                    if (health.IsDead == true)
                        _stats.OnKill();

                    targetsDamaged++;
                }
            }
        }

        private IEnumerable<Entity> GetNearestEnemies(Filter filter, Vector3 playerPosition)
        {
            var enemies = new List<Entity>();

            foreach (var enemy in filter)
                enemies.Add(enemy);

            Sort(enemies, 0, enemies.Count - 1, playerPosition);

            return enemies;
        }
        
        private void Sort(IList<Entity> array, int leftIndex, int rightIndex, Vector3 playerPosition)
        {
            float GetDistance(int index)
            {
                return Vector3.Distance(playerPosition, array[index].GetComponent<TransformComponent>().View.Position);
            }
            
            var i = leftIndex;
            var j = rightIndex;
            var pivot = GetDistance(leftIndex);

            while (i <= j)
            {
                while (GetDistance(i) < pivot)
                {
                    i++;
                }
        
                while (GetDistance(j) > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    i++;
                    j--;
                }
            }
    
            if (leftIndex < j)
                Sort(array, leftIndex, j, playerPosition);
            if (i < rightIndex)
                Sort(array, i, rightIndex, playerPosition);
        }
    }
}