using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameJamTools {
	public class Cutscene : MonoBehaviour {
        [SerializeField] protected UnityEvent StartCutsceneEvent;
        [SerializeField] protected List<UnityEvent> Events;
        [SerializeField] protected UnityEvent EndCutsceneEvent;

        static bool bCutsceneIsRunning = false;
        int EventIndex = 0;
        bool bBreakCutscene = false;

        protected virtual void Awake()
        {
            RunCutscene();
        }

        public void RunCutscene()
        {
            if (!bCutsceneIsRunning)
            {
                bCutsceneIsRunning = true;
                StartCutsceneEvent.Invoke();
                EventIndex = 0;

                ProgressCutsceneLoop();
            }
        }

        public void ContinueCutscene()
        {
            if (bBreakCutscene)
            {
                bBreakCutscene = false;
                ProgressCutsceneLoop();
            }
        }

        void ProgressCutsceneLoop()
        {
            for (; EventIndex < Events.Count; EventIndex++)
            {
                if (bBreakCutscene)
                {
                    return;
                }

                if (Events[EventIndex] != null)
                {
                    Events[EventIndex].Invoke();
                }
            }

            if (bBreakCutscene)
            {
                return;
            }

            EndCutsceneEvent.Invoke();
            EndCutscene();
        }

        public void PauseCutscene()
        {
            bBreakCutscene = true;
        }

        public void Delay(float Seconds)
        {
            StartCoroutine(DelayRoutine(Seconds));
        }

        void EndCutscene()
        {
            bCutsceneIsRunning = false;
        }

        IEnumerator DelayRoutine(float Seconds)
        {
            PauseCutscene();
            yield return new WaitForSeconds(Seconds);
            ContinueCutscene();
        }
	}
}