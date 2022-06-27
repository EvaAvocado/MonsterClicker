using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class ExitTriggerComponent : MonoBehaviour
    {
        [SerializeField] private String _tag;
        [SerializeField] private UnityEvent _action;

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _action?.Invoke();
            }
        }
    }
}