using Data;
using UIComponents;
using UnityEngine;
using UnityEngine.Events;

namespace Bonuses
{
    public class KillAllBust : Bust
    {
        [SerializeField] private UnityEvent _spawnText;
        
        private GameObject[] _monsters;
        private GameData _data;
        private ScoreComponent _score;
        private int _monstersCount;

        private void Awake()
        {
            _monsters = GameObject.FindGameObjectsWithTag("Monster");
            _data = FindObjectOfType<GameData>();
            _score = FindObjectOfType<ScoreComponent>();
        }

        protected override void Start()
        {
            _spawnText?.Invoke();
            base.Start();
        }

        [ContextMenu("BusterAction")]
        protected override void BusterAction()
        {
            _monstersCount = 0;
            foreach (var monster in _monsters)
            {
                if (monster != null)
                {
                    _monstersCount++;
                    Destroy(monster);
                }
            }

            _data.CurrentMonsters = 0;
            _score.ChangeScore(_monstersCount); 
        }
    }
}