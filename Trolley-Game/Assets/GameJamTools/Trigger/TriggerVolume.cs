using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameJamTools
{
	public abstract class TriggerVolume : MonoBehaviour
    {
        [HideInInspector] public List<string> Tags = new List<string>();
        [SerializeField] protected UnityEvent TriggerEvent;
        [SerializeField] protected bool bOnceOnly;

        public void Trigger(GameObject Triggerer)
        {
            foreach (string Tag in Tags)
            {
                if (Triggerer.CompareTag(Tag))
                {
                    TriggerEvent.Invoke();
                    if (bOnceOnly)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        Deactivate();
                    }
                    break;
                }
            }
        }

        public virtual void Deactivate()
        {
            // ?
        }

        public virtual void Reactivate()
        {
            // ?
        }
	}
}