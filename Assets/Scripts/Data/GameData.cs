using UnityEngine;
using UnityEngine.Events;

namespace Data
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private bool _isBust;
        [SerializeField] private int _score;
        [SerializeField] private int _currentMonsters;

        [Header("Deltas")] [SerializeField] private float _deltaSpeed;
        [SerializeField] private float _deltaHealth;
        [SerializeField] private float _deltaTimeSpawn;

        [Header("Event")] [SerializeField] private UnityEvent _loseAction;

        private bool _isLose;

        public bool IsBust
        {
            get { return _isBust; }
            set { _isBust = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public int CurrentMonsters
        {
            get { return _currentMonsters; }
            set { _currentMonsters = value; }
        }

        public float DeltaSpeed => _deltaSpeed;

        public float DeltaHealth => _deltaHealth;

        public float DeltaTimeSpawn => _deltaTimeSpawn;

        private void Update()
        {
            if (!_isBust)
            {
                _deltaHealth += Time.deltaTime / 25;
                _deltaSpeed += Time.deltaTime / 200;
                _deltaTimeSpawn += Time.deltaTime / 80;
            }

            if (_currentMonsters >= 10 && !_isLose)
            {
                _loseAction?.Invoke();
                _isLose = true;

            }
        }
    }
}