using Features.Player.StatsData.Config;

namespace Features.Player.StatsData
{
    public class StatHandle
    {
        public StatHandle(StatDefinition definition)
        {
            _definition = definition;
            _value = definition.DefaultValue;
            UpgradeChance = definition.UpgradeChance;
        }
        
        public readonly float UpgradeChance;

        private readonly StatDefinition _definition;

        private float _value;
        
        public float Value => _value;

        public bool IsUpgradable(float random)
        {
            if (random > _definition.UpgradeChance)
                return false;

            return true;
        }
        
        public void Upgrade()
        {
            _value += _definition.UpgradeStep;
        }
    }
}