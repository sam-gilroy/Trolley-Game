using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : PrefabbedSingleton<ScenarioManager> {
    public Scenario[] scenarios;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Test()
    {
        CharacterManager.Instance().SpawnScenario(Instance().scenarios[0]);
    }
}
