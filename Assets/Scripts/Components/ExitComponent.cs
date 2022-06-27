using UnityEngine;

namespace Components
{
    public class ExitComponent : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }
    }
}