using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterManager : MonoBehaviour
{
    private void Awake()
    {
        CharacterManager.Instance();
    }
}
