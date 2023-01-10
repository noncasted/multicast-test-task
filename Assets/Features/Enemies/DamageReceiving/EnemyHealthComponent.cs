using Morpeh;

namespace Features.Enemies.DamageReceiving
{
    public struct EnemyHealthComponent : IComponent
    {
        public EnemyHealthComponent(float health)
        {
            _health = health;
            _max = health;
            _isDead = false;
        }

        private readonly float _max;
        
        private float _health;
        private bool _isDead;

        public bool IsDead => _isDead;
        public float Normalized => _health / _max;

        public void OnDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
                _isDead = true;
        }
    }
}