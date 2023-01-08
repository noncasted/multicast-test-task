using System;
using System.Linq;
using Features.Player.StatsData.Abstract;
using Features.Player.StatsData.Config;
using UniRx;
using Random = UnityEngine.Random;

namespace Features.Player.StatsData
{
    public class Stats : IMovementStats, IAttackStats
    {
        public Stats(IPlayerStatsConfig config)
        {
            _speed = new StatHandle(config.Speed);
            _damagePerSecond = new StatHandle(config.DamagePerSecond);
            _attackRadius = new StatHandle(config.AttackRange);
            
            var stats = new[] { _speed, _damagePerSecond, _attackRadius };
            stats = stats.OrderBy(t => t.UpgradeChance).ToArray();

            _stats = stats;
        }
        
        private readonly StatHandle[] _stats;

        private IDisposable _upgradeClickListener;
        
        private readonly StatHandle _speed;
        private readonly StatHandle _damagePerSecond;
        private readonly StatHandle _attackRadius;

        public float Speed => _speed.Value;
        public float DamagePerSecond => _damagePerSecond.Value;
        public float AttackRadius => _attackRadius.Value;

        public void OnAwake()
        {
            _upgradeClickListener = MessageBroker.Default.Receive<UpgradeClickEvent>().Subscribe(OnUpgradeClicked);
        }

        public void Dispose()
        {
            _upgradeClickListener?.Dispose();
        }

        private void OnUpgradeClicked(UpgradeClickEvent data)
        {
            var random = Random.Range(0f, 100f);

            foreach (var stat in _stats)
            {
                if (stat.IsUpgradable(random) == false)
                    continue;
                
                stat.Upgrade();
            }
        }
    }
}