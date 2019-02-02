using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [System.Serializable]
    public class ParticlePoolInfo
    {
        public ParticleObject particlePrefab;
        public int sizePP;
    }

    public class ParticleManager : Singleton<ParticleManager>
    {
        Dictionary<ParticleObject, ParticlePool> ParticleObjectMap = new Dictionary<ParticleObject, ParticlePool>();

        public ParticleBehaviour Spawn()
        {
            return null;
        }

        ParticlePool AddPool(ParticleObject newObject)
        {
            GameObject temp = new GameObject(newObject.name + " Pool (" + ParticleObjectMap.Count.ToString() + ")");
            temp.transform.parent = transform;
            ParticlePool Pool = temp.AddComponent<ParticlePool>();
            Pool.InitializePool(newObject.GetParticle());
            ParticleObjectMap.Add(newObject, Pool);
            return Pool;
        }

        public ParticleBehaviour SpawnParticle(ParticleObject particleObject, Vector3 position)
        {
            return SpawnParticle(particleObject, position, Quaternion.identity);
        }

        public ParticleBehaviour SpawnParticle(ParticleObject particleObject, Transform transform)
        {
            ParticleBehaviour pb = SpawnParticle(particleObject, transform.position, transform.rotation);
            pb.transform.parent = transform;
            return pb;
        }

        public ParticleBehaviour SpawnParticle(ParticleObject particleObject, Vector3 position, Quaternion rotation)
        {
            ParticlePool Pool;
            if (ParticleObjectMap.ContainsKey(particleObject))
            {
                Pool = ParticleObjectMap[particleObject];
            }
            else
            {
               Pool = AddPool(particleObject);
            }
            return Pool.Spawn(position, rotation);
        }

    }
}