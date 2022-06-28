using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class PlaySoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioData[] _sounds;

        public AudioData[] Sounds => _sounds;
        public void PlayById(int id)
        {
            foreach (var audioData in _sounds)
            {
                if (audioData.Id != id) continue;

                _source.PlayOneShot(audioData.Clip);
                break;
            }
        }
        
        public void PlayByName(string name)
        {
            foreach (var audioData in _sounds)
            {
                if (audioData.Name != name) continue;

                _source.PlayOneShot(audioData.Clip);
                break;
            }
        }

        public void Mute()
        {
            _source.mute = true;
        }


        public void UnMute()
        {
            _source.mute = false;
        }

        [Serializable]
        public class AudioData
        {
            [SerializeField] private int _id;
            [SerializeField] private string _name;
            [SerializeField] private AudioClip _clip;

            public int Id => _id;
            public string Name => _name;
            public AudioClip Clip => _clip;
        }
    }
}