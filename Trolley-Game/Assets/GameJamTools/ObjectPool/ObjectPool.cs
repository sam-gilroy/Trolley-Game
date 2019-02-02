using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class ObjectPool<T> : Singleton<ObjectPool<T>> where T : AObjectPoolable
    {
        [SerializeField] T Prefab;

        Stack<T> RecycledObjects = new Stack<T>();

        /// <summary>
        /// Boilerplate stack management
        /// </summary>
        /// <returns></returns>
        public T Spawn()
        {
            T t = default(T);

            if (RecycledObjects.Count == 0)
            {
                t = Instantiate(Prefab) as T;
            }
            else
            {
                t = RecycledObjects.Pop();
                t.gameObject.SetActive(true);
                t.transform.parent = null;
            }

            // any non-parameterized setup goes here
            // overloads can call Spawn() and return the result
            PrivSpawn(t);

            return t;
        }

        /// <summary>
        /// We need one of these
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// 
        public T Spawn(Vector3 position)
        {
            T t = Spawn();
            t.transform.position = position;
            return t;
        }

        /// <summary>
        /// Override for custom setup (non-parameterised)
        /// </summary>
        /// <param name="t"></param>
        protected virtual void PrivSpawn(T t)
        {
            // Override me
            t.Spawn();
        }

        /// <summary>
        /// Puts things back in the stack
        /// </summary>
        /// <param name="t"></param>
        public virtual void Recycle(T t)
        {
            t.gameObject.SetActive(false);
            t.transform.parent = transform;
            RecycledObjects.Push(t);
        }

    }
}