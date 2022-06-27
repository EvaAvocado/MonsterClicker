using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Components
{
    public class ChooseRandomBusterComponent : MonoBehaviour
    {
        [SerializeField] private GameObjectEvent _action;

        private GameObject _prefab;
        
        public void ChooseRandomBuster()
        {
            switch (Random.Range(0, 3))
            {
                case 0: _prefab = Resources.Load<GameObject>("FreezingBuster");
                    break;
                case 1: _prefab = Resources.Load<GameObject>("KillAllBuster");
                    break;
                default: _prefab = Resources.Load<GameObject>("StopSpawnMonstersBuster");
                    break;
            }
            
            _action?.Invoke(_prefab);
        }
        
        [Serializable]
        public class GameObjectEvent : UnityEvent<GameObject>
        {
        
        }
    }
}