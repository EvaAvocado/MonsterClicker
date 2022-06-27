using UnityEngine;

namespace Data
{
    public class RecordsData : MonoBehaviour
    {
        private int[] _records = {-1, -1, -1, -1, -1};
        private GameData _data;

        private void Awake()
        {
            _data = FindObjectOfType<GameData>();
            SetRecords();
        }

        private void SetRecords()
        {
            if (PlayerPrefs.HasKey("RecordScore1"))
            {
                _records[0] = PlayerPrefs.GetInt("RecordScore1");
            }

            if (PlayerPrefs.HasKey("RecordScore2"))
            {
                _records[1] = PlayerPrefs.GetInt("RecordScore2");
            }

            if (PlayerPrefs.HasKey("RecordScore3"))
            {
                _records[2] = PlayerPrefs.GetInt("RecordScore3");
            }

            if (PlayerPrefs.HasKey("RecordScore4"))
            {
                _records[3] = PlayerPrefs.GetInt("RecordScore4");
            }

            if (PlayerPrefs.HasKey("RecordScore5"))
            {
                _records[4] = PlayerPrefs.GetInt("RecordScore5");
            }
        }
        
        public void CheckRecords(int score)
        {
            for (int i = 4; i >= 0; i--)
            {
                if (_records[i] < score)
                {
                    var temp = _records[i];
                    _records[i] = score;
                    if (i != 4)
                    {
                        _records[i + 1] = temp;
                    }
                }
            }
        }

        public void SaveRecords()
        {
            CheckRecords(_data.Score);

            // print(PlayerPrefs.GetInt("RecordScore1", _records[0]));
            // print(PlayerPrefs.GetInt("RecordScore1", _records[1]));
            // print(PlayerPrefs.GetInt("RecordScore1", _records[2]));
            // print(PlayerPrefs.GetInt("RecordScore1", _records[3]));
            // print(PlayerPrefs.GetInt("RecordScore1", _records[4]));
            
            PlayerPrefs.SetInt("RecordScore1", _records[0]);
            PlayerPrefs.SetInt("RecordScore2", _records[1]);
            PlayerPrefs.SetInt("RecordScore3", _records[2]);
            PlayerPrefs.SetInt("RecordScore4", _records[3]);
            PlayerPrefs.SetInt("RecordScore5", _records[4]);

            PlayerPrefs.Save();
        }

        public int GetRecords(int i)
        {
            return _records[i - 1];
        }
    }
}