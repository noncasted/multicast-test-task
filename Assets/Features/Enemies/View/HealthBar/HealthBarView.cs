using System;
using UnityEngine;

namespace Features.Enemies.View
{
    public class HealthBarView : MonoBehaviour, IHealthBarView
    {
        [SerializeField] private Transform _bar;

        private Vector3 _baseScale;

        private void Awake()
        {
            _baseScale = _bar.localScale;
        }

        public void SetNormalizedHealth(float health)
        {
            _bar.localScale = new Vector3(_baseScale.x, _baseScale.y, _baseScale.z * health);
        }
    }
}