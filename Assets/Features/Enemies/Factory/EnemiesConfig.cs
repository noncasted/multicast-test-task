using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Enemies.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Enemies", menuName = "Config/Enemies")]
    public class EnemiesConfig : ScriptableObject
    {
        [SerializeField] private EnemyConfig _small;
        [SerializeField] private EnemyConfig _medium;
        [SerializeField] private EnemyConfig _large;

        [SerializeField] private int _amountOnStart;

        public int AmountOnStart => _amountOnStart;
        
        public EnemyConfig GetRandom()
        {
            var random = Random.Range(0, 3);

            return random switch
            {
                0 => _small,
                1 => _medium,
                _ => _large
            };
        }
    }
}