using UnityEngine;

namespace Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _coorinateY;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var instantiate =  Instantiate(_prefab, _target.position, Quaternion.identity);
        }

        [ContextMenu("SpawnInCoordinates")]
        public void SpawnInCoordinates(double[] coordinates)
        {
            var instantiate = Instantiate(_prefab, new Vector3((float)coordinates[0], _coorinateY, (float)coordinates[1]), Quaternion.identity);
        }

        [ContextMenu("SpawnGameObject")]
        public void SpawnGameObject(GameObject prefab)
        {
            var instantiate =  Instantiate(prefab, _target.position, Quaternion.identity);
        }
    }
}