using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [CreateAssetMenu(fileName = "NewHitbox", menuName = "GameJamTools/Hitbox")]
    public class HitboxData : ScriptableObject
    {
        public float damage;
        public float duration;
        public Vector2 offset;
        public Vector2 size;
        public HITBOX_TYPE type;
    }
}