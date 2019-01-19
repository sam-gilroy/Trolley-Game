using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "GameJamTools/Projectile")]
    public class ProjectileData : ScriptableObject
    {
        public float damage;
        public float radius;
        public float speed;
        public float duration;
        public Sprite sprite;
        public AudioObject noise;
        public float gravity;
        public float ykick;
    }
}