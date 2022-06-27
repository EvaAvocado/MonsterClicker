using UnityEngine;

namespace Components
{
    public class LookAtCameraComponent : MonoBehaviour
    {
        private Quaternion _rotationToCamera;
        private Camera _camera;

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
        }

        private void Start()
        {
            _rotationToCamera = _camera.transform.rotation;
        }

        void Update()
        {
            if (gameObject.transform.rotation != _rotationToCamera)
            {
                gameObject.transform.rotation = _rotationToCamera;
            }
        }
    }
}
