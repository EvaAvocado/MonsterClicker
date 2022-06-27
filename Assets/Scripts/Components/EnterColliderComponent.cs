using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class EnterColliderComponent : MonoBehaviour
    {
        [SerializeField] private String _tag;
        [SerializeField] private UnityEvent _action;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _action?.Invoke();
            }
        }
    }
}