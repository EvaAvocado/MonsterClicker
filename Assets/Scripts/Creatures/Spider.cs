using UnityEngine;
using Random = UnityEngine.Random;

namespace Creatures
{
    public class Spider : Monster
    {

        protected override void Awake()
        {
            speed = 5;

            base.Awake();
        }
        
        
        public override void TurnBack()
        {
            base.TurnBack();
            rotationEnd =
                Quaternion.Euler(0, transform.rotation.eulerAngles.y + (Random.Range(0, 1) == 0 ? 120 : -120), 0);
        }
    }
}