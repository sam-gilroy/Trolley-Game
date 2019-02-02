using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {
    public static float difficulty { get; private set; }

    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] AudioMixer Mixer;

    float sfxVolume;
    float musicVolume;
    float masterVolume;

    public void Awake()
    {
        StartMenu();    
    }

    public void StartMenu()
    {
        difficulty = PlayerPrefs.GetFloat("Difficulty");
        sfxVolume = PlayerPrefs.GetFloat("SfxVolume");
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        masterVolume = PlayerPrefs.GetFloat("MasterVolume");

        sfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;
        masterSlider.value = masterVolume;

        sfxSlider.onValueChanged.AddListener(delegate { ChangeSfxVolume(sfxSlider.value); });
        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(musicSlider.value); });
        masterSlider.onValueChanged.AddListener(delegate { ChangeMasterVolume(masterSlider.value); });
        difficultySlider.onValueChanged.AddListener(delegate { difficulty = difficultySlider.value; });
    }

    public void ApplySettings()
    {
        Mixer.GetFloat("SfxVolume", out sfxVolume);
        Mixer.GetFloat("MusicVolume", out musicVolume);
        Mixer.GetFloat("MasterVolume", out masterVolume);
    }

    public void ChangeResolution()
    {

    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ExitSettings()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitSettings();
        }
    }

    public void ChangeSfxVolume(float value)
    {
        Debug.Log(value);
        Mixer.SetFloat("SfxVolume", value);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }

    public void ChangeMusicVolume(float value)
    {
        Mixer.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void ChangeMasterVolume(float value)
    {
        Mixer.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

}
