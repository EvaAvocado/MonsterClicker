using Creatures;
using UnityEngine;

namespace Components
{
    public class StopAllComponent : MonoBehaviour
    {
        private GameObject[] _monsters;
        private GameObject[] _spawners;
        private Terrain _terrain;
        
        public void StopAllMonsters()
        {
            _monsters = GameObject.FindGameObjectsWithTag("Monster");
            _spawners = GameObject.FindGameObjectsWithTag("Spawner");
            _terrain = FindObjectOfType<Terrain>();

            _terrain.terrainData.wavingGrassStrength = 0;
            
            foreach (var monster in _monsters)
            {
                if (monster != null)
                {
                    monster.GetComponent<Animator>().speed = 0;
                    monster.GetComponent<Monster>().StopMove = true;
                }
            }
            
            foreach (var spawner in _spawners)
            {
                spawner.GetComponent<TimerComponent>().enabled = false;
            }
        }
    }
}