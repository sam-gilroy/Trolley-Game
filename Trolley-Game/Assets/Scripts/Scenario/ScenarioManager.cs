using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : PrefabbedSingleton<ScenarioManager> {
    public Scenario[] scenarios;
    int currentScenario = 0;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Test()
    {
        CharacterManager.Instance().SpawnScenario(Instance().scenarios[0]);
    }

    public void GoToNextScenario()
    {
        CharacterManager.Instance().RecallAllCharacters();

        currentScenario++;
        if (currentScenario >= scenarios.Length)
        {
            GameManager.Instance().CompleteGame();
            return;
        }

        StartScenario();
    }

    public void StartScenario()
    {
        CharacterManager.Instance().SpawnScenario(Instance().scenarios[currentScenario]);
    }

    public void GoToScenario(int i)
    {
        CharacterManager.Instance().RecallAllCharacters();

        currentScenario = i;

        StartScenario();
    }

}
