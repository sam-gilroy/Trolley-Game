using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Hitbox : AObjectPoolable
    {
        BoxCollider2D boxCollider2D;
        float damage;
        HITBOX_TYPE type;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
        }

        public override void Recycle()
        {
            base.Recycle();
            HitboxFactory.Instance().Recycle(this);
        }

        public override void Spawn()
        {
            // Do nothing?
        }

        public virtual void Spawn(HitboxParams Params, HitboxData data)
        {
            Spawn();

            this.transform.parent = Params.transform;

            if (this.transform.parent == null)
                this.transform.position = data.offset;
            else
                this.transform.localPosition = new Vector2(data.offset.x * Params.xSide, data.offset.y);


            type = data.type;
            boxCollider2D.size = data.size;
            damage = data.damage;
            Invoke("Recycle", data.duration);
        }

        public HITBOX_TYPE GetHitboxType()
        {
            return type;
        }

        public float GetDamage()
        {
            return damage;
        }

        public void SetDamage(float damage)
        {
            this.damage = damage;
        }

        public void ScaleDamage(float scale)
        {
            damage *= scale;
        }
    }
}