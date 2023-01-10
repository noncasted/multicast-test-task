namespace Features.Player.Attack
{
    public class EnemyKillEvent
    {
        public EnemyKillEvent(int amount)
        {
            Amount = amount;
        }
        
        public readonly int Amount;
    }
}