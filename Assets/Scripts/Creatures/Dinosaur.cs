using UnityEngine;

namespace Creatures
{
    public class Dinosaur : Monster
    {
        private Animator _animator;
        private static readonly int EnterBorder = Animator.StringToHash("enter-border");

        protected override void Awake()
        {
            _animator = GetComponent<Animator>();
            speed = 5;

            base.Awake();
        }
        
        public void StartAnimEnterBorder()
        {
            _animator.SetTrigger(EnterBorder);
        }
    }
}