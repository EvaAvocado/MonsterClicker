using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class LoadSceneComponent : MonoBehaviour
    {
        [SerializeField] private string _nextScene;
        
        public void LoadScene()
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}