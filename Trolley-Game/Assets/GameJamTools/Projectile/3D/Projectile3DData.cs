using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [CreateAssetMenu(fileName = "NewProjectile3D", menuName = "GameJamTools/Projectile3D")]
    public class Projectile3DData : ScriptableObject
    {
        public float damage;
        public float radius;
        public float speed;
        public float duration;
        public Mesh mesh;
        public Material material;
        public AudioObject noise;
    }

}