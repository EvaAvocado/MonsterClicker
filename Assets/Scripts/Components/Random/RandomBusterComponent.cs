using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class RandomBusterComponent : MonoBehaviour
    {
        [SerializeField] private int _randStart;
        [SerializeField] private int _randEnd;
        [SerializeField] private int _randTruePercent;
        [SerializeField] private UnityEvent _action;

        private GameData _data;

        private void Awake()
        {
            _data = FindObjectOfType<GameData>();
        }
        
        public void RandomAction()
        {
            var i = Random.Range(_randStart, _randEnd);
            if (_randTruePercent >= i && !_data.IsBust)
            {
                _action?.Invoke();
            }
        }
    }
}