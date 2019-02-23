using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [CreateAssetMenu(fileName = "NewParticle", menuName = "GameJamTools/ParticleObject")]
	public class ParticleObject : ScriptableObject {
        [SerializeField] ParticleBehaviour ParticlePrefab;
        [SerializeField] ParticleSystem.MainModule mainmodule;

        public ParticleBehaviour GetParticle()
        {
            return ParticlePrefab;
        }

        public ParticleBehaviour Spawn(Vector3 position)
        {
            return ParticleManager.Instance().SpawnParticle(this, position, Quaternion.identity);
        }

        public ParticleBehaviour Spawn(Transform transform)
        {
            return ParticleManager.Instance().SpawnParticle(this, transform.position, transform.rotation);
        }

        public ParticleBehaviour Spawn(Vector3 position, Quaternion rotation)
        {
            return ParticleManager.Instance().SpawnParticle(this, position, rotation);
        }

    }
}
