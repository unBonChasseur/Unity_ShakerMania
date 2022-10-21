#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Visit.Random
{
    public class RandomGameObject : MonoBehaviour
    {
        #region Inspector
#pragma warning disable 0649

        [SerializeField]
        private bool ReplaceAtStart;

        [SerializeField]
        private RandomGameObjectData data_random;

#pragma warning restore 0649
        #endregion

        public GameObject to_replace;

        private void Update()
        {
            if (to_replace.transform.position.y < .5f)
                to_replace.transform.position = transform.position;
        }
        public void ReplaceByRandomObject()
        {
            to_replace = transform.childCount != 0 ? transform.GetChild(0).gameObject : null;
            ReplaceRandomObject(transform.position, transform.rotation);
        }

        public void ReplaceRandomObject(Vector3 position, Quaternion rotation)
        {
            GameObject obj = data_random.GetRandomObject();
            GameObject instance = null;
            if (obj != null)
            {
#if UNITY_EDITOR
                if (Application.isEditor)
                {
                    instance = PrefabUtility.InstantiatePrefab(obj, transform) as GameObject;
                    instance.transform.position = position;
                    instance.transform.rotation = rotation;
                }
                else
                {
#endif
                    instance = Instantiate(
                    obj,
                    position,
                    rotation,
                    transform);
#if UNITY_EDITOR
                }
#endif
                //instance.transform.SetChildLayers(gameObject.layer);
            }
            if (to_replace != null)
            {
                Destroy(to_replace);
            }

            to_replace = instance;
        }
    }
}