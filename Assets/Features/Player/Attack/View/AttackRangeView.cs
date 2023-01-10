using UnityEngine;

namespace Features.Player.Attack.View
{
    [DisallowMultipleComponent]
    public class AttackRangeView : MonoBehaviour, IAttackRangeView
    {
        [SerializeField] private Transform _view;
        [SerializeField] private float _height = 0.01f;
        
        public void SetRange(float range)
        {
            var doubled = range * 2f;
            _view.localScale = new Vector3(doubled, _height, doubled);
        }
    }
}