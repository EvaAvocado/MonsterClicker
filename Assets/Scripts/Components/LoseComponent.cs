using System;
using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class LoseComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _actionIfLose;
        
        private GameData _data;
        private bool _isLose;

        private void Awake()
        {
            _data = FindObjectOfType<GameData>();
        }

        private void Update()
        {
            if (!_isLose && _data.CurrentMonsters >= 10)
            {
                _isLose = true;
                _actionIfLose?.Invoke();
            }
        }
    }
}
