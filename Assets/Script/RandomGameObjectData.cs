using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visit.Random
{
    /// <summary>
    /// Random data, handle the probability law and the collection of prefabs associated.
    /// </summary>
    [CreateAssetMenu(fileName = "NewRandomGameObjectData", menuName = "RandomGameObjectData", order = 1)]
    public class RandomGameObjectData : ScriptableObject
    {
        #region Inspector
#pragma warning disable 0649

        [SerializeField]
        private AnimationCurve _law_random = AnimationCurve.Linear(0, 0, 1, 1);

        [SerializeField]
        private GameObject[] _prefabs;

#pragma warning restore 0649
        #endregion

#if UNITY_EDITOR
        public GameObject[] Prefabs { get => _prefabs; set => _prefabs = value; }
#endif

        public GameObject GetRandomObject()
        {
            if (_prefabs.Length == 0)
            {
                Debug.LogError("Empty random data prefabs");
                return null;
            }
            float normProba = _law_random.Evaluate(UnityEngine.Random.value);
            int ran = (int)(normProba * _prefabs.Length);
            return _prefabs[ran];
        }
    }
}
