namespace Features.Player.StatsData.Config
{
    public interface IPlayerStatsConfig
    {
        StatDefinition Speed { get; }
        StatDefinition DamagePerSecond { get; }
        StatDefinition AttackRange { get; }
    }
}