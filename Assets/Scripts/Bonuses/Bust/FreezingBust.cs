using Components;
using Creatures;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Bonuses
{
    public class FreezingBust : Bust
    {
        private GameObject[] _monsters;
        private GameObject[] _spawners;
        private GameObject _camera;
        private void Awake()
        {
            duration = 5;
            _monsters = GameObject.FindGameObjectsWithTag("Monster");
            _spawners = GameObject.FindGameObjectsWithTag("Spawner");
            _camera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        
        protected override void BusterAction()
        {
            _camera.GetComponent<PostProcessLayer>().enabled = true;
            
            foreach (var monster in _monsters)
            {
                if (monster != null)
                {
                    monster.GetComponent<Animator>().speed = 0;
                    monster.GetComponent<Monster>().stopMove = true;
                }
            }

            foreach (var spawner in _spawners)
            {
                spawner.GetComponent<TimerComponent>().enabled = false;
            }
            
            base.BusterAction();
        }

        protected override void EndAction()
        {
            _camera.GetComponent<PostProcessLayer>().enabled = false;
            
            foreach (GameObject monster in _monsters)
            {
                if (monster != null)
                {
                    monster.GetComponent<Animator>().speed = 1;
                    monster.GetComponent<Monster>().stopMove = false;
                }
            }
            
            foreach (var spawner in _spawners)
            {
                spawner.GetComponent<TimerComponent>().enabled = true;
            }
            
            base.EndAction();
        }
    }
}