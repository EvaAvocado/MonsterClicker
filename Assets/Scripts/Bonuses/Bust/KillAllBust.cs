using UnityEngine;
using UnityEngine.Events;

namespace Bonuses
{
    public class KillAllBust : Bust
    {
        [SerializeField] private UnityEvent _spawnText;
        private GameObject[] _monsters;

        private void Awake()
        {
            _monsters = GameObject.FindGameObjectsWithTag("Monster");
        }

        protected override void Start()
        {
            _spawnText?.Invoke();
            base.Start();
        }

        [ContextMenu("BusterAction")]
        protected override void BusterAction()
        {
            foreach (var monster in _monsters)
            {
                if (monster != null)
                {
                    Destroy(monster);
                }
            }
        }
    }
}