using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance()
        {
            if (instance == null)
            {
                instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
            }

            return instance;
        }

        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public static void Terminate()
        {
            Destroy(instance.gameObject);
            instance = null;
        }

        protected virtual void Reset()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                Debug.LogError("You cannot put Singletons into the scene via editor -- they must be instantiated by calling Instance()");
                DestroyImmediate(this);
            }
#endif
        }

    }
}
