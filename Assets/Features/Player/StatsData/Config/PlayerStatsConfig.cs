using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Player.StatsData.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Stats", menuName = "Config/PlayerStats")]
    public class PlayerStatsConfig : ScriptableObject, IPlayerStatsConfig
    {
        [SerializeField] private StatDefinition _speed;
        [SerializeField] private StatDefinition _damagePerSecond;
        [SerializeField] private StatDefinition _attackRadius;

        [SerializeField] private int _maxTargets;
        
        public StatDefinition Speed => _speed;
        public StatDefinition DamagePerSecond => _damagePerSecond;
        public StatDefinition AttackRange => _attackRadius;
        public int MaxTargets => _maxTargets;
    }
}