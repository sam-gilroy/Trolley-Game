using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [System.Serializable]
	public class FxEvent{
        [SerializeField] public EventType eventType = EventType.Particle;
        [SerializeField] public ParticleEvent particleEvent;
        [SerializeField] public AudioEvent audioEvent;
        [SerializeField] public CameraEvent cameraEvent;
        static CameraController2D cameraController = null;

        public FxEvent()
        {
        }

        public void Invoke()
        {
            switch (eventType)
            {
                case EventType.Particle:
                    InvokeParticle();
                    break;
                case EventType.Audio:
                    InvokeAudio();
                    break;
                case EventType.Camera:
                    InvokeCamera();
                    break;
            }
        }

        public void InvokeParticle()
        {
            if (particleEvent.bUseTransform)
            {
                ParticleManager.Instance().SpawnParticle(particleEvent.particleObject, particleEvent.transform.position);
            }
            else
            {
                ParticleManager.Instance().SpawnParticle(particleEvent.particleObject, particleEvent.position);
            }
        }

        public void InvokeAudio()
        {
            AudioManager.Instance().Play(audioEvent.audioObject);
        }

        public void InvokeCamera()
        {
            if (cameraController == null)
            {
                cameraController = Camera.main.GetComponent<CameraController2D>();
            }

            switch (cameraEvent.EventType)
            {
                case CameraEventType.Position:
                    cameraController.SetTargetPosition(cameraEvent.position);
                    break;
                case CameraEventType.Transform:
                    cameraController.SetTargetTransform(cameraEvent.transform);
                    break;
                case CameraEventType.Shake:
                    cameraController.CameraShake(cameraEvent.shakeDir, cameraEvent.shakeRate, cameraEvent.shakeDecay);
                    break;
                case CameraEventType.Push:
                    cameraController.CameraPush(cameraEvent.pushDir);
                    break;
            }
        }

    }

    public enum EventType
    {
        None = 0,
        Particle,
        Audio,
        Camera
    }

    [System.Serializable]
    public class ParticleEvent
    {
        public ParticleObject particleObject;
        public bool bUseTransform;
        public Transform transform;
        public Vector3 position;
    }

    [System.Serializable]
    public class AudioEvent
    {
        public AudioObject audioObject;
    }

    [System.Serializable]
    public class CameraEvent
    {
        public CameraEventType EventType;

        public Vector2 position;

        public Transform transform;

        public Vector2 shakeDir;
        public float shakeRate;
        public float shakeDecay;

        public Vector2 pushDir;
    }

    [System.Serializable]
    public enum CameraEventType
    {
        Transform,
        Position,
        Shake,
        Push
    }


}