using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Components
{
    public class RandomCirclePointComponent : MonoBehaviour
    {
        [SerializeField] private Coordinates _action;

        public void ChooseRandomPointInCircle()
        {
            var angle = Random.Range(0.0f, 1.0f) * 2 * Math.PI;
            var radius = Math.Sqrt(Random.Range(0.0f, 135.0f));
            double[] result = {radius * Math.Cos(angle), radius * Math.Sin(angle)};
            _action?.Invoke(result);
        }

        [Serializable]
        public class Coordinates : UnityEvent<double[]>
        {
        }
    }
}