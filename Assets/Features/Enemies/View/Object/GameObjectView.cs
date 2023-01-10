using UnityEngine;

namespace Features.Enemies.View.Object
{
    public class GameObjectView : MonoBehaviour, IGameObjectView
    {
        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}