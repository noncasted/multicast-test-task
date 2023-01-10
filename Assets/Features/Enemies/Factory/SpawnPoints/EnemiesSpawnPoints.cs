using UnityEngine;

namespace Features.Enemies.Factory.SpawnPoints
{
    public class EnemiesSpawnPoints : MonoBehaviour, IEnemiesSpawnPoints
    {
        [SerializeField] private Transform[] _points;
        
        public Vector3 GetRandom()
        {
            var random = Random.Range(0, _points.Length);

            return _points[random].position;
        }
    }
}