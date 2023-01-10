using UnityEngine;

namespace Features.Enemies.View.Transform
{
    public class TransformView : MonoBehaviour, ITransformView
    {
        public Vector3 Position => transform.position;
    }
}