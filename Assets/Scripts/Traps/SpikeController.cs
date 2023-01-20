using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class SpikeController : MonoBehaviour
    {
        [SerializeField] private Transform allSpikes;

        private List<Transform> allLeftSpikes;
        private List<Transform> allRightSpikes;
        private List<Transform> allBottomSpikes;
        private List<Transform> allTopSpikes;

        private List<Transform> spikesPos = new List<Transform>();
        private List<Spike> spikes = new List<Spike>();
        // Start is called before the first frame update
        void Start()
        {
            for(int i = 0; i < allSpikes.childCount; i++)
            {
                foreach (Transform t in allSpikes.GetChild(i))
                {

                }
            }
        }
        public void SpawnIdleSpike()
        {
            Spike currentSpike = GetRandomFreeSpike();
            if (currentSpike != null)
                SpawnSpike(currentSpike);
        }
        private Spike GetRandomFreeSpike()
        {
            return spikes[0];
        }
        private void SpawnSpike(Spike spike)
        {
            return;
        }
    }
}
