using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleBehaviour : AObjectPoolable
    {
        ParticlePool owningPool;
        new ParticleSystem particleSystem;
        public bool active { get; private set; }

        // Use this for initialization
        void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        public void SetParticlePool(ParticlePool pool)
        {
            this.owningPool = pool;
        }

        public ParticlePool GetParticlePool()
        {
            return owningPool;
        }

        // Update is called once per frame
        void Update()
        {
            if (active)
            {
                if (!particleSystem.main.loop)
                {
                    if (!particleSystem.isPlaying)// && particleSystem.particleCount == 0)
                    {
                        Recycle();
                    }
                }
            }
        }

        public override void Spawn()
        {
            active = true;
            particleSystem.Play(true);
        }

        public override void Recycle()
        {
            active = false;
            particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            transform.parent = null;
            StartCoroutine(RecycleRoutine());
        }

        IEnumerator RecycleRoutine()
        {
            while (true)
            {
                yield return null;
                if (particleSystem.particleCount == 0)
                {
                    owningPool.Recycle(this);
                    yield break;
                }
            }
        }
    }
}