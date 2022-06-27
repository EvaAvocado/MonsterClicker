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

        private void Awake()
        {
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
            if (_isRandom)
            {
                _time = Random.Range(3, _time);
            }
        }
    }
}