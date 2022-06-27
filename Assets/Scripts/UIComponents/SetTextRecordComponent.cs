using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class SetTextRecordComponent : MonoBehaviour
    {
        [SerializeField] private int _recordNumber;
        [SerializeField] private RecordsData _recordsData;

        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
            
            if (_recordsData.GetRecords(_recordNumber) != -1)
            {
                _text.text = "" + _recordsData.GetRecords(_recordNumber);
            }
        }
    }
}