using System;
using Features.Common.Worlds;
using Features.Player.Attack.View;
using Features.Player.Input;
using Features.Player.Movement.View;
using Features.Player.Root;
using Features.Player.StatsData;
using Features.Player.StatsData.Components;
using Features.Player.StatsData.Config;
using Morpeh;
using UnityEngine;

namespace Features.Player.Factory
{
    [DisallowMultipleComponent]
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject _prefab;
        
        public void Spawn(IEntityCreator entityCreator, PlayerStatsConfig config)
        {
            var view = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            
            if (view.TryGetComponent(out IRigidBodyView rigidBodyView) == false)
                throw new ArgumentException();

            if (view.TryGetComponent(out IPlayerRoot root) == false)
                throw new ArgumentException();
            
            if (view.TryGetComponent(out IAttackRangeView rangeView) == false)
                throw new ArgumentException();
            
            var stats = new Stats(config);
            root.Construct(stats);

            var transformComponent = new RigidBodyComponent(rigidBodyView);
            var movementStatsComponent = new MovementStatsComponent(stats);
            var attackStatsComponent = new AttackStatsComponent(stats);
            var movementInputComponent = new MovementInputComponent();
            var attackRangeViewComponent = new AttackRangeViewComponent(rangeView);
            
            var entity = entityCreator.Create();
            
            entity.SetComponent(transformComponent);
            entity.SetComponent(movementStatsComponent);
            entity.SetComponent(attackStatsComponent);
            entity.SetComponent(movementInputComponent);
            entity.SetComponent(attackRangeViewComponent);
        }
    }
}