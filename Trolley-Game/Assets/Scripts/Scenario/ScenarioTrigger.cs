using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioTrigger : MonoBehaviour {
    private void Awake()
    {
        ScenarioManager.Instance().StartScenario();
    }
}
