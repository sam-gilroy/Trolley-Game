using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PrefabbedSingleton<GameManager> {
    public Object GameScene;

    public void StartGame()
    {
        SceneManager.LoadScene(GameScene.name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CompleteGame()
    {
        GoToMainMenu();
        // ScenarioManager.Instance().GoToScenario(0);
    }

}
