using System.Collections.Generic;
using UnityEngine;

namespace JamBCD
{
    public class SceneData : MonoBehaviour
    {
        [System.Serializable]
        public class WaveData
        {
            public List<GameObject> Enemies;
        }
        
        public PlayerView PlayerView;
        public float IntervalBetweenWaves;
        public List<WaveData> Waves;
    }
}