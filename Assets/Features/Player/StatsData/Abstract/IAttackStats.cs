namespace Features.Player.StatsData.Abstract
{
    public interface IAttackStats
    {
        float DamagePerSecond { get; }
        float AttackRadius { get; }
    }
}