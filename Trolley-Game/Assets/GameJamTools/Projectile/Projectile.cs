using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : AObjectPoolable
    {
        protected SpriteRenderer spriteRenderer;
        protected CircleCollider2D circleCollider2D;
        protected new Rigidbody2D rigidbody2D;
        protected float damage;
        protected HITBOX_TYPE hitboxType;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            circleCollider2D = GetComponent<CircleCollider2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public override void Recycle()
        {
            base.Recycle();
            ProjectileFactory.Instance().Recycle(this);
        }

        public override void Spawn()
        {
            // Do Nothing
        }

        public void Spawn(ProjectileParams Param, ProjectileData Data)
        {
            Spawn();

            transform.position = Param.position;
            transform.rotation = Quaternion.Euler(Vector3.forward * Param.angle);
            hitboxType = Param.hitboxType;

            damage = Data.damage;
            circleCollider2D.radius = Data.radius;
            spriteRenderer.sprite = Data.sprite;
            rigidbody2D.gravityScale = Data.gravity;
            rigidbody2D.velocity = transform.right * Data.speed + Vector3.up * Data.ykick;
            AudioManager.Instance().Play(Data.noise);
            Invoke("Recycle", Data.duration);
        }

        public float GetDamage()
        {
            return damage;
        }

        public HITBOX_TYPE GetHitboxType()
        {
            return hitboxType;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}