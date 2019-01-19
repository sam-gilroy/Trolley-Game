using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    [SerializeField] List<CharacterAttributes> Attributes = new List<CharacterAttributes>();

    public Character(List<CharacterAttributes> attributes)
    {
        Attributes = attributes;
    }

    public List<CharacterAttributes> GetAttributes()
    {
        List<CharacterAttributes> RetList = new List<CharacterAttributes>();
        foreach (CharacterAttributes Attribute in Attributes)
        {
            RetList.Add(Attribute);
        }
        return RetList;
    }

    public bool HasAttribute(CharacterAttributes Attribute)
    {
        return Attributes.Contains(Attribute);
    }

    public void AddAttribute(CharacterAttributes Attribute)
    {
        Attributes.Add(Attribute);
    }

}
