using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] protected float Health = 100.0f;
        [SerializeField] protected float Regen = 0.1f;
        protected float MaxHealth;

        /// <summary>
        /// Take Damage
        /// </summary>
        /// <param name="Damage"></param>
        public virtual void TakeDamage(float Damage)
        {
            Health -= Damage;
            if (Health <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Default: destroy gameobject
        /// </summary>
        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}