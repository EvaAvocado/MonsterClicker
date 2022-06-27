using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Buster
{
    public class Buster : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UnityEvent _clickAction;

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            _clickAction?.Invoke();
        }
    }
}