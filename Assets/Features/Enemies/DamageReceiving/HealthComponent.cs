using Morpeh;

namespace Features.Enemies.DamageReceiving
{
    public struct HealthComponent : IComponent
    {
        private float _health;
        private bool _isDead;

        public bool IsDead => _isDead;

        public void OnDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
                _isDead = true;
        }
    }
}