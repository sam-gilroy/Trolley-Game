using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJamTools
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] string GamePlaySceneName;
        [SerializeField] Settings settingsPrefab;

        public void StartGame()
        {
            SceneManager.LoadScene(GamePlaySceneName);
        }

        public void EndGame()
        {
            Debug.Log("Ending Game");
            Application.Quit();
        }

        public void OpenSettings()
        {
            Instantiate(settingsPrefab, Vector3.zero, Quaternion.identity);
        }

    }
}