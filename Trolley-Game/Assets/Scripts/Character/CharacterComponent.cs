// Luke Mayo, 2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour {
    [SerializeField] List<CharacterAttributes> Attributes;

    public Character GetCharacter()
    {
        return new Character(Attributes);
    }

    public void SetCharacter(Character character)
    {
        Attributes = character.GetAttributes();
    }
}
