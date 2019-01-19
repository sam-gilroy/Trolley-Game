using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlatformingController : MonoBehaviour
    {
        [SerializeField] protected float WalkSpeed = 1;
        [SerializeField] protected float JumpSpeed = 5;
        [SerializeField] protected bool bCanJump = true;
        protected new Rigidbody2D rigidbody2D;
        protected BoxCollider2D boxCollider2D;
        protected bool bIsAutoWalking = false;
        protected float lastSide = 1;
        protected float WalkScale = 1;

        // Use this for initialization
        protected virtual void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            gravityScale = rigidbody2D.gravityScale;
        }

        /// <summary>
        /// Walk command -- to be called externally
        /// </summary>
        /// <param name="h"></param>
        public virtual void Walk(float h)
        {
            bIsAutoWalking = false;
            privWalk(h);
        }

        /// <summary>
        /// Base "walking" behaviour
        /// </summary>
        /// <param name="h"></param>
        protected virtual void privWalk(float h)
        {
            rigidbody2D.velocity = new Vector2(h * WalkSpeed * WalkScale, rigidbody2D.velocity.y);
            if (h != 0)
            {
                lastSide = Mathf.Sign(h);
            }
        }
        /// <summary>
        /// Jump command
        /// </summary>
        public virtual void Jump()
        {
            if (IsOnGround() && bCanJump)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpSpeed);
            }
        }

        /// <summary>
        /// Checks for ground
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOnGround()
        {
            Debug.DrawLine((Vector2)transform.position + boxCollider2D.offset + Vector2.down * ((boxCollider2D.size.y / 2) + .01f),
                ((Vector2)transform.position + boxCollider2D.offset + Vector2.down * ((boxCollider2D.size.y / 2) + .01f)) + (Vector2.down * 0.01f),
                Color.green,1);

            return (Physics2D.Raycast((Vector2)transform.position + boxCollider2D.offset + Vector2.down * ((boxCollider2D.size.y / 2) + .01f), Vector2.down, 0.01f).collider != null);
        }

        /// <summary>
        /// saves gravscale for freezing
        /// </summary>
        protected float gravityScale;

        /// <summary>
        /// Freezes
        /// </summary>
        public virtual void Freeze()
        {
            rigidbody2D.velocity = Vector2.zero;
            gravityScale = rigidbody2D.gravityScale;
            rigidbody2D.gravityScale = 0;
        }

        /// <summary>
        /// Unfreezes
        /// </summary>
        public virtual void UnFreeze()
        {
            rigidbody2D.gravityScale = gravityScale;
        }

        /// <summary>
        /// In case
        /// </summary>
        /// <param name="gravityScale"></param>
        public virtual void SetGravityScale(float gravityScale)
        {
            rigidbody2D.gravityScale = gravityScale;
        }

        /// <summary>
        /// Hard set both components
        /// </summary>
        /// <param name="newVelocity"></param>
        public virtual void SetVelocity(Vector2 newVelocity)
        {
            rigidbody2D.velocity = newVelocity;
        }

        /// <summary>
        /// Set just Y
        /// </summary>
        /// <param name="y"></param>
        public virtual void SetVelY(float y)
        {
            rigidbody2D.velocity
                 = new Vector2(rigidbody2D.velocity.x, y);
        }

        /// <summary>
        /// Set just X
        /// </summary>
        /// <param name="x"></param>
        public virtual void SetVelX(float x)
        {
            rigidbody2D.velocity
                 = new Vector2(x, rigidbody2D.velocity.y);
        }

        public BoxCollider2D GetBoxCollider()
        {
            return boxCollider2D;
        }

        public Rigidbody2D GetRigidbody2D()
        {
            return rigidbody2D;
        }

        public bool CanJump()
        {
            return bCanJump;
        }

        public bool IsAutoWalking()
        {
            return bIsAutoWalking;
        }

        public void SetCanJump(bool bCanJump)
        {
            this.bCanJump = bCanJump;
        }

        public virtual void Move(Vector2 dir, float scale = 1)
        {
            rigidbody2D.velocity = dir * scale;
        }

        public virtual void MoveTo(float x)
        {
            StopAllCoroutines();
            StartCoroutine(MoveToRoutine(x));
        }

        public void SetWalkScale(float WalkScale)
        {
            this.WalkScale = WalkScale;
        }

        public float GetWalkScale()
        {
            return WalkScale;
        }

        IEnumerator MoveToRoutine(float x)
        {
            bIsAutoWalking = true;
            float signX = Mathf.Sign(x - transform.position.x);
            while (bIsAutoWalking)
            {
                if (signX == Mathf.Sign(x - transform.position.x))
                {
                    privWalk(signX);
                    yield return null;
                }
                else
                {
                    privWalk(0);
                    bIsAutoWalking = false;
                    transform.position = new Vector3(x, transform.position.y, transform.position.z);
                    yield break;
                }
            }
        }
    }
}