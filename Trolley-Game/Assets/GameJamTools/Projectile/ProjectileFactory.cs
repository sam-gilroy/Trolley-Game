using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class ProjectileFactory : ObjectPool<Projectile>
    {

        public static new ProjectileFactory Instance()
        {
            return ObjectPool<Projectile>.Instance() as ProjectileFactory;
        }

        public Projectile Spawn(ProjectileParams Param, ProjectileData data)
        {
            Projectile projectile = Spawn();
            projectile.Spawn(Param, data);
            return projectile;
        }
    }
}