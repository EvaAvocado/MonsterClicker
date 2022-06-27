using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Bonuses
{
    public class Bust : MonoBehaviour
    {
        [SerializeField] private Text _text;
        protected float duration;
        
        [SerializeField] private GameData _data;
        
        protected virtual void Start()
        {
            _data = FindObjectOfType<GameData>();
            if (_text != null)
            {
                _text.text = "Duration: " + ((int) duration + 1);
            }
        }

        private void Update()
        {
            if (duration >= 0)
            {
                BusterAction();
            }
            else
            {
                EndAction();
            }

            duration -= Time.deltaTime;
            if (_text != null)
            {
                _text.text = "Duration: " + ((int) duration + 1);
            }
        }

        protected virtual void BusterAction()
        {
            _data.IsBust = true;
        }

        protected virtual void EndAction()
        {
            _data.IsBust = false;
            Destroy(gameObject);
        }
    }
}