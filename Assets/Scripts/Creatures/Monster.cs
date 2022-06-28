using Data;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

namespace Creatures
{
    public class Monster : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] protected float speed;
        [SerializeField] private bool _stopMoveInAnimation;
        
        [Header("Events")]
        [SerializeField] private UnityEvent _clickerAction;

        protected Quaternion rotationEnd;

        private Quaternion _rotationStart;
        private Quaternion _rotation;
        private float _waitTime;
        private float _rotationTime;
        private bool _rotationAllowed;
        private bool _stopMove;

        private Rigidbody _rb;
        private GameData _data;

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public bool StopMoveInAnimation
        {
            get { return _stopMoveInAnimation; }
            set { _stopMoveInAnimation = value; }
        }

        public bool StopMove
        {
            get { return _stopMove; }
            set { _stopMove = value; }
        }

        protected virtual void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _data = FindObjectOfType<GameData>();

            _rotationStart = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            rotationEnd = Quaternion.Euler(0, Random.Range(-170, 170), 0);
            _rotation = _rotationStart;
        }

        private void Start()
        {
            _data.CurrentMonsters++;
            speed += _data.DeltaSpeed;
        }

        protected virtual void FixedUpdate()
        {
            if (!_stopMoveInAnimation && !StopMove)
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
            if (!_stopMoveInAnimation && !StopMove)
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
            if (speed == 0)
            {
                _rotation = Quaternion.Slerp(_rotationStart, _rotationStart, 0);
            }

            _rb.velocity = _rotation * new Vector3(0, _rb.velocity.y, -speed);
            transform.rotation = _rotation;
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            _clickerAction?.Invoke();
        }
    }
}