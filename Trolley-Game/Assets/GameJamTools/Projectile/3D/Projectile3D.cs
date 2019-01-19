using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile3D : AObjectPoolable
    {
        protected MeshFilter meshFilter;
        protected SphereCollider sphereCollider;
        protected MeshRenderer meshRenderer;
        protected new Rigidbody rigidbody;
        protected float damage;

        public override void Spawn()
        {
            // ???
        }

        private void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
            sphereCollider = GetComponent<SphereCollider>();
            rigidbody = GetComponent<Rigidbody>();
            meshRenderer = GetComponent<MeshRenderer>();
            rigidbody.useGravity = false;
            sphereCollider.isTrigger = true;
        }


        public void Spawn(Projectile3DParams Params, Projectile3DData Data)
        {
            Spawn();
            transform.position = Params.position;
            transform.forward = Params.direction;
            damage = Data.damage;
            sphereCollider.radius = Data.radius;
            meshFilter.mesh = Data.mesh;
            meshRenderer.material = Data.material;
            rigidbody.velocity = transform.forward * Data.speed;
            AudioManager.Instance().Play(Data.noise);
            Invoke("Recycle", Data.duration);
        }

        public override void Recycle()
        {
            base.Recycle();
            Projectile3DFactory.Instance().Recycle(this);
        }

    }
}