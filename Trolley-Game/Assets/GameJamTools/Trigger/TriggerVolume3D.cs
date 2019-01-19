using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJamTools;

namespace GameJamTools
{
    [RequireComponent(typeof(BoxCollider))]
    public class TriggerVolume3D : TriggerVolume
    {
        BoxCollider boxCollider;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }

        public override void Deactivate()
        {
            boxCollider.enabled = false;
        }

        public override void Reactivate()
        {
            boxCollider.enabled = true;
        }

        private void OnTriggerEnter(Collider collision)
        {
            Trigger(collision.gameObject);
        }
    }
}