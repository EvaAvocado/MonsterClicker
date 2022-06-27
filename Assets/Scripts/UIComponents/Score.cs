using UnityEngine;
using UnityEngine.UI;

namespace UIComponents
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text _text;
        
        private int _currentScore;
        
        public void ChangeScore(int count)
        {
            _currentScore += count;
            _text.text = "Score: " + _currentScore;
        }
    }
}