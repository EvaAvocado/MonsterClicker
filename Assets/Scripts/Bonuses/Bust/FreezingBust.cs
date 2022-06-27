using System;
using System.Collections.Generic;
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
            _camera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        protected override void BusterAction()
        {
            _monsters = GameObject.FindGameObjectsWithTag("Monster");
            _spawners = GameObject.FindGameObjectsWithTag("Spawner");

            _camera.GetComponent<PostProcessLayer>().enabled = true;

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

            base.BusterAction();
        }

        protected override void EndAction()
        {
            _camera.GetComponent<PostProcessLayer>().enabled = false;

            foreach (var monster in _monsters)
            {
                if (monster != null)
                {
                    monster.GetComponent<Animator>().speed = 1;
                    monster.GetComponent<Monster>().StopMove = false;
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