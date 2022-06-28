using System;
using Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Buster
{
    public class Buster : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UnityEvent _clickAction;

        private GameData _data;

        private void Awake()
        {
            _data = FindObjectOfType<GameData>();
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            if (!_data.IsBust)
            {
                _clickAction?.Invoke();
            }
        }
    }
}