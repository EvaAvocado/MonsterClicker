using Components;
using UnityEngine;

namespace Bonuses
{
    public class StopSpawnMonstersBust : Bust
    {
        private GameObject[] _spawners;
        private void Awake()
        {
            duration = 5;
            _spawners = GameObject.FindGameObjectsWithTag("Spawner");
        }
        
        protected override void BusterAction()
        {
            foreach (var spawner in _spawners)
            {
                spawner.GetComponent<TimerComponent>().enabled = false;
            }
            
            base.BusterAction();
        }

        protected override void EndAction()
        {
            foreach (var spawner in _spawners)
            {
                spawner.GetComponent<TimerComponent>().enabled = true;
            }
            
            base.EndAction();
        }
    }
}