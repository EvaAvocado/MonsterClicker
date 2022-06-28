using Creatures;
using UnityEngine;

namespace Components
{
    public class StopStartSpawnComponent : MonoBehaviour
    {
        private GameObject[] _spawners;
        private Terrain _terrain;
        
        public void StopSpawn()
        {
            _spawners = GameObject.FindGameObjectsWithTag("Spawner");
            _terrain = FindObjectOfType<Terrain>();

            _terrain.terrainData.wavingGrassStrength = 0;
            
            foreach (var spawner in _spawners)
            {
                spawner.GetComponent<TimerComponent>().enabled = false;
            }
        }

        public void StartSpawn()
        {
            _terrain.terrainData.wavingGrassStrength = 0.5f;
            
            foreach (var spawner in _spawners)
            {
                spawner.GetComponent<TimerComponent>().enabled = true;
            }
        }
    }
}