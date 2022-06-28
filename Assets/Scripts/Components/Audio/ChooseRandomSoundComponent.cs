using UnityEngine;

namespace Components
{
    public class ChooseRandomSoundComponent : MonoBehaviour
    {
        [SerializeField] private PlaySoundComponent _sounds;

        public void PlayRandSound()
        {
            int randSound = Random.Range(0, _sounds.Sounds.Length);
            foreach (var audio in _sounds.Sounds)
            {
                if (audio.Id == randSound)
                {
                    _sounds.PlayById(audio.Id);
                }
            }
        }
    }
}