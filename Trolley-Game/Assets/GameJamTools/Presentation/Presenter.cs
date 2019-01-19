using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameJamTools {
	public abstract class Presenter : MonoBehaviour {
        [SerializeField] protected UnityEvent EndPresentationEvent;

        public abstract void Present();
        public abstract void ContinuePresentation();
        public virtual void EndPresentation()
        {
            EndPresentationEvent.Invoke();
        }

    }
}