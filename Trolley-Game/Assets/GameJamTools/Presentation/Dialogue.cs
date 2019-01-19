using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace GameJamTools
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class Dialogue : Presenter
    {
        [SerializeField] Text text;
        [TextArea(3,10)]
        [SerializeField] List<string> paragraphs;
        [SerializeField] float letterTime = 0.01f;
        [SerializeField] AudioObject talkNoise;
        [SerializeField] List<KeyCode> acceptableProgressionKeyCodes;
        [SerializeField] bool anyKeyProgression;

        float letterTimer = 0;

        int charIndex = 0;
        int paragraphIndex = 0;

        bool bIsRunning = false;

        protected virtual void Update()
        {
            if (bIsRunning)
            {
                RunParagraph();
                ProcessInput();
            }
        }

        protected virtual void StartParagraph()
        {
            text.text = "";
            charIndex = 0;
        }

        protected virtual void RunParagraph()
        {
            letterTimer -= Time.deltaTime * Time.timeScale;
            if (letterTimer <= 0f)
            {
                if (charIndex < paragraphs[paragraphIndex].Length)
                {
                    letterTimer = letterTime;
                    text.text += paragraphs[paragraphIndex][charIndex];
                    AudioManager.Instance().Play(talkNoise);
                    charIndex++;
                }
            }
        }

        protected virtual void ProcessInput()
        {
            bool Progress = (anyKeyProgression && Input.anyKeyDown);
            foreach (KeyCode keyCode in acceptableProgressionKeyCodes)
            {
                if (Progress)
                    break;
                Progress = Progress || Input.GetKeyDown(keyCode);
            }

            if (Progress)
            {
                if (IsRunningParagraph())
                {
                    JumpToEndOfParagraph();
                }
                else
                {
                    ContinuePresentation();
                }
            }
        }

        protected virtual void JumpToEndOfParagraph()
        {
            charIndex = 999;
            text.text = paragraphs[paragraphIndex];
        }

        protected virtual bool IsRunningParagraph() { return charIndex < paragraphs[paragraphIndex].Length; }

        public override void Present()
        {
            paragraphIndex = 0;
            bIsRunning = true;
            StartParagraph();
        }

        public override void ContinuePresentation()
        {
            paragraphIndex++;
            if (paragraphIndex >= paragraphs.Count)
            {
                EndPresentation();
            }
            else
            {
                StartParagraph();
            }
        }

        public override void EndPresentation()
        {
            base.EndPresentation();
            bIsRunning = false;
            enabled = false;
        }
    }
}