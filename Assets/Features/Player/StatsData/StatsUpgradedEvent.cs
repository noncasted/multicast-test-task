namespace Features.Player.StatsData
{
    public class StatsUpgradedEvent
    {
        public StatsUpgradedEvent(float speed, float damage, float range)
        {
            Speed = speed;
            Damage = damage;
            Range = range;
        }
        
        public readonly float Speed;
        public readonly float Damage;
        public readonly float Range;
    }
}