using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJamTools;

namespace JDE {

    /// <summary>
    /// Editor scripts and monobehaviours alike can access this singleton -- lifetime: unity editor
    /// 
    /// survives scene change
    /// does not survive opening project
    /// does not survive enteriing playmode
    /// survives exiting playmode
    /// 
    /// unity singletons are weird because they must be initted on awake, or constructed on awake
    /// so either SEO, or write two scripts?
    /// plus if you instantiate instead, you always have to spawn shit
    /// </summary>
    public class Testleton
    {
        private static Testleton instance;
        int num = 0;

        public static Testleton Instance()
        {
            if (instance == null)
            {
                instance = new Testleton();
            }
            return instance;
        }

        public void PrintNum()
        {
            Debug.Log(++num);
        }

        public void SpawnGameObject(MonoBehaviour Caller)
        {
            new GameObject("Singleton Spawned");
        }
	}


}