using System;
using UnityEngine;

namespace Features.Enemies.Factory
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField] private float _health;
        [SerializeField] private GameObject _prefab;

        public float Health => _health;
        public GameObject Prefab => _prefab;
    }
}