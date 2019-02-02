using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public interface Particle_IPoolable
    {
        void Spawn();
        void Recycle();
    }
}