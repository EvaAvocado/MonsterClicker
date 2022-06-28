using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class AwakeActionComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _awakeAction;

        private void Awake()
        {
            _awakeAction?.Invoke();
        }
    }
}