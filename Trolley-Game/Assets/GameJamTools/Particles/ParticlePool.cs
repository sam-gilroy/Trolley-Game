using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class ParticlePool : MonoBehaviour
    {
        int sizeOfPool;
        int currentObject;
        Stack<ParticleBehaviour> recycledParticleBehaviours = new Stack<ParticleBehaviour>();
        ParticleBehaviour particlePrefab;

        public void InitializePool(ParticleBehaviour particlePrefab)
        {
            this.particlePrefab = particlePrefab;
        }

        ParticleBehaviour Spawn()
        {
            ParticleBehaviour newParticle = null;
            if (recycledParticleBehaviours.Count == 0)
            {
                newParticle = Instantiate(particlePrefab) as ParticleBehaviour;
                newParticle.SetParticlePool(this);
            }
            else
            {
                newParticle = recycledParticleBehaviours.Pop();
            }
            newParticle.gameObject.SetActive(true);
            newParticle.Spawn();
            return newParticle;
        }
        // Spawn Particle Overloads
        public ParticleBehaviour Spawn(Vector3 position)
        {
            ParticleBehaviour newParticle = Spawn();
            newParticle.transform.position = position;
            newParticle.transform.rotation = Quaternion.identity;
            newParticle.transform.parent = null;
            return newParticle;
        }
         
        public ParticleBehaviour Spawn(Vector3 position, Quaternion rotation)
        {
            ParticleBehaviour newParticle = Spawn();
            newParticle.transform.position = position;
            newParticle.transform.rotation = rotation;
            newParticle.transform.parent = null;
            return newParticle;
        }

        public ParticleBehaviour Spawn(Transform transform)
        {
            ParticleBehaviour newParticle = Spawn();
            newParticle.transform.parent = transform;
            newParticle.transform.localPosition = Vector3.zero;
            newParticle.transform.localRotation = Quaternion.identity;
            return newParticle;
        }

        public void Recycle(ParticleBehaviour particleBehaviour)
        {
            recycledParticleBehaviours.Push(particleBehaviour);
            particleBehaviour.gameObject.SetActive(false);
            particleBehaviour.transform.parent = transform;
        }
    }
}