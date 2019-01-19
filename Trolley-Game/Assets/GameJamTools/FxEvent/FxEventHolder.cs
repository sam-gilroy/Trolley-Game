using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
	public class FxEventHolder : MonoBehaviour {
        [SerializeField] List<FxEvent> events;
        [SerializeField] bool bOnStart;

        private void Start()
        {
            if (bOnStart)
            {
                PlayEvents();
            }
        }

        public void PlayEvents()
        {
            foreach (FxEvent _event in events)
            {
                _event.Invoke();
            }
        }
	}
}