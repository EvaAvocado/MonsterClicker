using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class TimerComponent : MonoBehaviour
    {
        [SerializeField] private float _time;
        [SerializeField] private float _timeToStart;
        [SerializeField] private bool _isRandom;
        [SerializeField] private UnityEvent _action;
        
        private float _timeBeforeApplyAction;
        private GameData _data;

        private void Awake()
        {
            _data = FindObjectOfType<GameData>();
            CheckRandom();
            _timeBeforeApplyAction = _time;
        }

        private void Update()
        {
            if (_timeToStart <= 0)
            {
                Timer();
            }
            else
            {
                _timeToStart -= Time.deltaTime;
            }
        }

        private void Timer()
        {
            _timeBeforeApplyAction -= Time.deltaTime;
            if (_timeBeforeApplyAction <= 0)
            {
                CheckRandom();
                _timeBeforeApplyAction = _time;
                _action?.Invoke();
            }
        }

        private void CheckRandom()
        {
            var firstRand = Random.Range(2, 5);
            var secondRand = Random.Range(5, 10);
            
            if (_isRandom)
            {
                _time = Random.Range((firstRand - _data.DeltaTimeSpawn) < 0 ? 0 : firstRand ,  (secondRand - _data.DeltaTimeSpawn) < 1 ? 1 : secondRand);
            }
        }
    }
}