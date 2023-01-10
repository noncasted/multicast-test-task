using System;
using Features.Player.StatsData;
using TMPro;
using UniRx;
using UnityEngine;

namespace Features.UI
{
    [DisallowMultipleComponent]
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text _speed;
        [SerializeField] private TMP_Text _damage;
        [SerializeField] private TMP_Text _range;

        private IDisposable _upgradeListener;

        private void OnEnable()
        {
            _upgradeListener = MessageBroker.Default.Receive<StatsUpgradedEvent>().Subscribe(OnStatsUpgraded);
        }

        private void OnDisable()
        {
            _upgradeListener?.Dispose();
        }

        private void OnStatsUpgraded(StatsUpgradedEvent data)
        {
            _speed.text = $"Speed: {data.Speed}";
            _damage.text = $"Damage: {data.Damage}";
            _range.text = $"Range: {data.Range}";
        }
    }
}