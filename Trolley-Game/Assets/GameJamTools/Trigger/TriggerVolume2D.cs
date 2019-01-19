using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [RequireComponent(typeof(BoxCollider2D))]
	public class TriggerVolume2D : TriggerVolume {
        BoxCollider2D boxCollider2D;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;
        }

        public override void Deactivate()
        {
            boxCollider2D.enabled = false;
        }

        public override void Reactivate()
        {
            boxCollider2D.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Trigger(collision.gameObject);
        }
    }
}