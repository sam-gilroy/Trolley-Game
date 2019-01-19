using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour, ISingleton
    {
        /// <summary>
        /// Makes singleton eternal uwu
        /// </summary>
        [SerializeField] protected bool Permanant;

        private static T instance;

        /// <summary>
        /// Finds Object if null -- iff still null (not awakened) die
        /// </summary>
        /// <returns></returns>
        public static T Instance()
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.LogError("A " + typeof(T).ToString() + " must be in the scene");
                }
                else
                {
                    instance.Init();
                }
            }

            return instance;
        }

        /// <summary>
        /// Sets singleton to this
        /// </summary>
        private void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                instance.Init();
                PrivInit();
                if (Permanant)
                    DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                DestroyImmediate(this);
            }
        }

        /// <summary>
        /// Terminates Singleton
        /// </summary>
        public virtual void Terminate()
        {
            if (!Permanant)
            {
                instance = null;
                PrivTerminate();
                Destroy(this);
            }
        }

        /// <summary>
        /// For all your initialization needs
        /// </summary>
        protected virtual void PrivInit() { }

        /// <summary>
        /// For all your termination needs
        /// </summary>
        protected virtual void PrivTerminate() { }
    }
}