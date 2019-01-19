using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public enum HITBOX_TYPE
    {
        PLAYER,
        ENEMY,
    }

    public class HitboxParams
    {
        public Transform transform = null;
        public float xSide = 1f;
    }
}