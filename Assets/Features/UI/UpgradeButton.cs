using Features.Player.StatsData;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Features.UI
{
    [DisallowMultipleComponent]
    public class UpgradeButton : MonoBehaviour
    {
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.AddListener(OnClicked);
        }
        
        private void OnClicked()
        {
            var data = new UpgradeClickEvent();

            MessageBroker.Default.Publish(data);
        }
    }
}