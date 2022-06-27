using UnityEngine;

namespace Data
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private bool _isBust;

        public bool IsBust
        {
            get { return _isBust; }
            set { _isBust = value; }
        }
    }
}