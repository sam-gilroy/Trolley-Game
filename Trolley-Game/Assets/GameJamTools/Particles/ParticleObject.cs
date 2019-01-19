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
	}
}