using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UIComponents
{
    public class ScoreComponent : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private int _currentScore;
        private GameData _data;

        private void Awake()
        {
            _data = FindObjectOfType<GameData>();
        }

        public void ChangeScore(int count)
        {
            _currentScore += count;
            _text.text = "Score: " + _currentScore;
            _data.Score = _currentScore;
        }
    }
}