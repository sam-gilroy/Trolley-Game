using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    /// <summary>
    /// Note for potential refactor: This could work better as a component that has related components implement "IPoolable" to reset data. . . 
    /// This would avoid issues with Multiple Inheritance.
    /// 
    /// As to whether or not adding a second component (or requiring it?) is too complicated is another question.
    /// </summary>
    public abstract class AObjectPoolable : MonoBehaviour
    {

        /// <summary>
        /// Spawn without arguments
        /// </summary>
        public abstract void Spawn();

        /// <summary>
        /// Spawn with a position
        /// </summary>
        /// <param name="position"></param>
        public virtual void Spawn(Vector3 position)
        {
            Spawn();
            transform.position = position;
        }

        /// <summary>
        /// Spawn with aposition / rotation
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        public virtual void Spawn(Vector3 position, Quaternion rotation)
        {
            Spawn();
            transform.position = position;
            transform.rotation = rotation;
        }

        /// <summary>
        /// Sends it back to its pool
        /// </summary>
        public virtual void Recycle()
        {
            CancelInvoke();
        }

    }
}