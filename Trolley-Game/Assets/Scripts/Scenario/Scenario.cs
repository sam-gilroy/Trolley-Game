using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScenario", menuName = "Trolley/Scenario")]
public class Scenario : ScriptableObject {
    public CharacterComponent[] StayCharacters;
    public CharacterComponent[] SwitchCharacters;
}
