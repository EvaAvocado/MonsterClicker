using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class RandomTimeBusterComponent : MonoBehaviour
    {
        [SerializeField] private int _randStart;
        [SerializeField] private int _randEnd;
        [SerializeField] private int _randTrue;
        [SerializeField] private UnityEvent _action;

        [SerializeField] private GameData _data;

        private void Awake()
        {
            _data = FindObjectOfType<GameData>();
        }
        
        public void RandomAction()
        {
            if (_randTrue <= Random.Range(_randStart, _randEnd) && !_data.IsBust)
            {
                _action?.Invoke();
            }
        }
    }
}