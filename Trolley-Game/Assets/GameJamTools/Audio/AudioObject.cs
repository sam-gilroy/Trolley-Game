using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [CreateAssetMenu(fileName = "AudioObject", menuName = "GameJamTools/AudioObject")]
    public class AudioObject : ScriptableObject
    {
        [SerializeField] AudioClip[] clips;
        [SerializeField] float baseVolume = 1.0f;
        [SerializeField] float randomVolume;
        [SerializeField] float basePitch = 1.0f;
        [SerializeField] float randomPitch;
        [SerializeField] bool isLooping;

        public void Play(AudioSource audioSource)
        {
            audioSource.volume = baseVolume + Random.Range(-randomVolume, randomVolume) * 0.5f;
            audioSource.pitch = basePitch + Random.Range(-randomPitch, randomPitch) * 0.5f;
            audioSource.loop = isLooping;
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }
}