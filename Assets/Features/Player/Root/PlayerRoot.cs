using Features.Player.StatsData;
using UnityEngine;

namespace Features.Player.Root
{
    public class PlayerRoot : MonoBehaviour, IPlayerRoot
    {
        private Stats _stats;

        public void Construct(Stats stats)
        {
            _stats = stats;
            
            _stats.OnAwake();
            _stats.Publish();
        }

        private void OnDestroy()
        {
            _stats.Dispose();
        }
    }
}