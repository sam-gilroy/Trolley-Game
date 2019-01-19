using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class HitboxFactory : ObjectPool<Hitbox>
    {

        public static new HitboxFactory Instance()
        {
            return ObjectPool<Hitbox>.Instance() as HitboxFactory;
        }

        public Hitbox Spawn(HitboxParams Params, HitboxData data)
        {
            Hitbox hitbox = Spawn();
            hitbox.Spawn(Params, data);
            return hitbox;
        }

    }
}