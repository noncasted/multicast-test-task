using UnityEngine;

namespace Features.Enemies.View
{
    public class GameObjectView : MonoBehaviour, IGameObjectView
    {
        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}