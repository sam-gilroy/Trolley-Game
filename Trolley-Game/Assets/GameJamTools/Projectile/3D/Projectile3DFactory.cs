using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class Projectile3DFactory : ObjectPool<Projectile3D>
    {

        public static new Projectile3DFactory Instance()
        {
            return ObjectPool<Projectile3D>.Instance() as Projectile3DFactory;
        }

        public Projectile3D Spawn(Projectile3DParams Param, Projectile3DData data)
        {
            Projectile3D projectile = Spawn();
            projectile.Spawn(Param, data);
            return projectile;
        }
    }
}