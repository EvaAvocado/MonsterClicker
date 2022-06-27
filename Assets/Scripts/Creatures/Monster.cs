using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

namespace Creatures
{
    public class Monster : MonoBehaviour, IPointerClickHandler
    {
        public bool stopMove;
        [SerializeField] protected float speed;
        [SerializeField] private UnityEvent _clickerAction;

        protected Quaternion rotationEnd;
        
        private Quaternion _rotationStart;
        private Quaternion _rotation;
        private float _waitTime;
        private float _rotationTime;
        private bool _rotationAllowed;

        private Rigidbody _rb;

        protected virtual void Awake()
        {
            _rb = GetComponent<Rigidbody>();

            _rotationStart = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            rotationEnd = Quaternion.Euler(0, Random.Range(-170, 170), 0);
            _rotation = _rotationStart;
        }

        protected virtual void FixedUpdate()
        {
            if (!stopMove)
            {
                DoPatrol();
            }
        }

        private void DoPatrol()
        {
            if (_rotationAllowed)
            {
                DoRotation();
            }
            else
            {
                _waitTime -= Time.deltaTime;
                if (_waitTime < 0)
                {
                    _rotationAllowed = true;
                }

                _rb.velocity = _rotation * new Vector3(0, _rb.velocity.y, -speed);
            }
        }

        public virtual void TurnBack()
        {
            if (!stopMove)
            {
                _rotationTime = 0;
                _rotationAllowed = true;
                _rotationStart = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                rotationEnd =
                    Quaternion.Euler(0, transform.rotation.eulerAngles.y + (Random.Range(0, 1) == 0 ? 105 : -105), 0);

            }
        }

        private void DoRotation()
        {
            _rotationTime += Time.deltaTime;
            if (_rotationTime > 1)
            {
                _rotationTime = 0;
                _rotationStart = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                rotationEnd = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Random.Range(-170, 170), 0);

                _rotationAllowed = false;
                _waitTime = Random.Range(1, 3);
            }

            _rotation = Quaternion.Slerp(_rotationStart, rotationEnd, _rotationTime);
            _rb.velocity = _rotation * new Vector3(0, _rb.velocity.y, -speed);
            transform.rotation = _rotation;
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            _clickerAction?.Invoke();
        }
    }
}