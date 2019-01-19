using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class PlayerManager : Singleton<PlayerManager>, ISingleton
    {
        [SerializeField] UPlayer Player;

        public UPlayer GetPlayer()
        {
            return Player;
        }

        public void Init()
        {
            PrivInit();
        }
    }
}