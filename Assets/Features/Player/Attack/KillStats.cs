using UniRx;

namespace Features.Player.Attack
{
    public class KillStats
    {
        private int _counter = 0;
        
        public void OnKill()
        {
            _counter++;

            var data = new EnemyKillEvent(_counter);
            MessageBroker.Default.Publish(data);
        }
    }
}