using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameJamTools;

public class PauseMenu : MonoBehaviour {
    [SerializeField] UPlayer Controller;
    [SerializeField] Canvas PauseCanvas;
    [SerializeField] string MainMenuName;
    [SerializeField] Settings SettingsPrefab;
    bool bIsPaused = false;

    private void Awake()
    {
        PauseCanvas.gameObject.SetActive(false);
    }

    public void Pause()
    {
        PauseCanvas.gameObject.SetActive(true);
        Controller.enabled = false;
        Time.timeScale = 0;
        bIsPaused = true;
    }

    public void UnPause()
    {
        PauseCanvas.gameObject.SetActive(false);
        Controller.enabled = true;
        bIsPaused = false;
        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        Instantiate(SettingsPrefab, Vector3.zero, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bIsPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MainMenuName);
    }


}
