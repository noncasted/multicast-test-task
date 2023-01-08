using System;
using UnityEngine;

namespace Features.Player.StatsData.Config
{
    [Serializable]
    public class StatDefinition
    {
        [SerializeField] private float _defaultValue;
        [SerializeField] private float _upgradeStep;
        [SerializeField] private float _upgradeChance;

        public float DefaultValue => _defaultValue;
        public float UpgradeStep => _upgradeStep;
        public float UpgradeChance => _upgradeChance;
    }
}