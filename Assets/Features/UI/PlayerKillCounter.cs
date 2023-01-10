using System;
using Features.Player.Attack;
using TMPro;
using UniRx;
using UnityEngine;

namespace Features.UI
{
    [DisallowMultipleComponent]
    public class PlayerKillCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private IDisposable _killListener;

        private void OnEnable()
        {
            _killListener = MessageBroker.Default.Receive<EnemyKillEvent>().Subscribe(OnKill);
        }
        
        private void OnDisable()
        {
            _killListener.Dispose();
        }

        private void OnKill(EnemyKillEvent data)
        {
            _text.text = $"Kills: {data.Amount}";
        }
    }
}