using UnityEngine;

namespace Features.Enemies.Factory.SpawnPoints
{
    public interface IEnemiesSpawnPoints
    {
        Vector3 GetRandom();
    }
}