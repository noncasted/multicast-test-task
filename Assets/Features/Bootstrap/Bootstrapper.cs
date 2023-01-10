using Features.Common.Worlds;
using Features.Enemies.DamageReceiving;
using Features.Enemies.Factory;
using Features.Enemies.Factory.SpawnPoints;
using Features.Player.Attack;
using Features.Player.Attack.View;
using Features.Player.Factory;
using Features.Player.Input;
using Features.Player.Movement;
using Features.Player.StatsData.Config;
using Morpeh;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.Bootstrap
{
    [DisallowMultipleComponent]
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputSystem _input;
        [SerializeField] private MovementSystem _movement;
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private DeathCheckSystem _deathCheck;
        [SerializeField] private AttackSystem _attack;
        [SerializeField] private HealthViewUpdateSystem _healthViewUpdate;
        [SerializeField] private AttackRangeViewUpdateSystem _attackRangeViewUpdate;
        
        [SerializeField] private WorldHandler _worldHandler;
        [SerializeField] private EnemiesSpawnPoints _spawnPoints;
        
        [SerializeField] private EnemiesConfig _enemiesConfig;
        [SerializeField] private PlayerStatsConfig _playerConfig;

        private void Awake()
        {
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }

        private void Start()
        {
            Bootstrap();
        }

        private void Bootstrap()
        {
            var world = World.Create();
            var worldView = new WorldView(world);

            var systemsGroup = world.CreateSystemsGroup();

            var enemiesFactory = new EnemyFactory(_spawnPoints, worldView, _enemiesConfig);
            
            _deathCheck.Construct(enemiesFactory);
            _attack.Construct(_playerConfig.MaxTargets);
            
            systemsGroup.AddSystem(_input);
            systemsGroup.AddSystem(_movement);
            systemsGroup.AddSystem(_deathCheck);
            systemsGroup.AddSystem(_attack);
            systemsGroup.AddSystem(_healthViewUpdate);
            systemsGroup.AddSystem(_attackRangeViewUpdate);

            world.AddSystemsGroup(0, systemsGroup);

            _worldHandler.Construct(world);
            _playerFactory.Spawn(worldView, _playerConfig);
            
            enemiesFactory.SpawnStartup();
        }
    }
}