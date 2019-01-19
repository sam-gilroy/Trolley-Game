using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GameJamTools
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : Singleton<AudioManager>, ISingleton
    {
        AudioSource[] sources;
        AudioSource musicSource;
        AudioClip fadeInClip;
        [SerializeField] int sourceCount = 10;
        [SerializeField] float FadeSpeed = 1f;
        [SerializeField] AudioMixerGroup SfxMixer;

        int currentSource;
        float defaultVolume;

        protected override void PrivInit()
        {
            musicSource = GetComponent<AudioSource>();
            defaultVolume = musicSource.volume;
            sources = new AudioSource[sourceCount];
            for (int i = 0; i < sourceCount; i++)
            {
                AudioSource temp = gameObject.AddComponent<AudioSource>();
                temp.outputAudioMixerGroup = SfxMixer;
                temp.loop = false;
                temp.playOnAwake = false;
                temp.Stop();
                sources[i] = temp;
            }
        }

        // Gets the current playing AudioSource
        public AudioSource GetAudioSource()
        {
            int s = currentSource;
            currentSource = (currentSource + 1) % sourceCount;

            return sources[s];
        }

        /// <summary>
        /// Searches for a free audio source and plays it, returning the source. 
        /// The returned source can be used to stop a looping sound later.
        /// </summary>
        /// <param name="audio"></param>
        /// <returns></returns>
        public AudioSource Play(AudioObject audio)
        {
            int s = currentSource;
            currentSource = (currentSource + 1) % sourceCount;

            while (sources[currentSource].loop && sources[currentSource].isPlaying) // Find a non-looping sound
            {
                currentSource = (currentSource + 1) % sourceCount;
                if (currentSource == s)
                    return null;
            }

            audio.Play(sources[currentSource]);

            s = currentSource;
            return sources[s];
        }

        /// <summary>
        /// Wrapper function that allows sounds to be played via UnityEvent
        /// </summary>
        /// <param name="audio"></param>
        /// <returns></returns>
        public void PlayEvent(AudioObject audio)
        {
            Play(audio);
        }

        /// <summary>
        /// Plays music without fade option for events
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="fade"></param>
        public void PlayMusic(AudioClip clip)
        {
            PlayMusic(clip, false);
        }

        /// <summary>
        /// Plays music with fade option
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="fade"></param>
        public void PlayMusic(AudioClip clip, bool fade)
        {
            if (!fade)
            {
                InterruptFade();
                musicSource.clip = clip;
                musicSource.Play();
            }
            else
            {
                fadeInClip = clip;
                StartCoroutine(Fade(true));
            }
        }

        /// <summary>
        /// Stops music with fade option
        /// </summary>
        /// <param name="fade"></param>
        public void StopMusic(bool fade = false)
        {
            if (fade)
            {
                StartCoroutine(Fade(false));
            }
            else
            {
                InterruptFade();
                musicSource.Stop();
            }
        }

        /// <summary>
        /// If you call startmusic while fading out, that call will be overruled by the fade's music -- This is called in Stop and StartMusic to prevent that.
        /// </summary>
        void InterruptFade()
        {
            StopAllCoroutines();
            musicSource.volume = defaultVolume;
        }

        /// <summary>
        /// Fade routine
        /// </summary>
        /// <param name="bPlayNext"></param>
        /// <returns></returns>
        IEnumerator Fade(bool bPlayNext)
        {
            while (musicSource.volume > 0)
            {
                musicSource.volume -= Time.deltaTime * FadeSpeed;
                yield return null;
            }

            musicSource.Stop();
            musicSource.volume = defaultVolume;

            if (bPlayNext)
            {
                musicSource.clip = fadeInClip;
                musicSource.Play();
            }
        }

        public void Init()
        {
            // ??
        }

    }
}