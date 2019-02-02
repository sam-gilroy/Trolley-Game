using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ApplySettings : MonoBehaviour {
    [SerializeField] AudioMixer Mixer;

	void Start () {
        Mixer.SetFloat("SfxVolume", PlayerPrefs.GetFloat("SfxVolume"));
        Mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        Mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));

    }
}
