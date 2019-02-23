// Luke Mayo, 2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJamTools;

public class StatisticsManager : Singleton<StatisticsManager> {

    List<Character> StayVictims =   new List<Character>();
    List<Character> SwitchVictims = new List<Character>();

    // =============================| RECORDING STATISTICS |======================================== //
    public void RecordStayAction(List<Character> CharactersKilled)
    {
        foreach (Character character in CharactersKilled)
        {
            StayVictims.Add(character);
        }
    }

    public void RecordSwitchAction(List<Character> CharactersKilled)
    {
        foreach (Character character in CharactersKilled)
        {
            SwitchVictims.Add(character);
        }
    }

    // =============================| GETTING STATISTICS |======================================== //
    public float GetKillPercent(CharacterAttributes Attribute)
    {
        float SwitchKilled = GetKillPercent_Switch(Attribute);
        float StayKilled = GetKillPercent_Stay(Attribute);

        return (SwitchKilled + StayKilled) / 2;
    }

    public float GetKillPercent_Switch(CharacterAttributes Attribute)
    {
        float numCharacters = SwitchVictims.Count;
        float numAttributes = 0;

        foreach (Character character in SwitchVictims)
        {
            if (character.GetAttributes().Contains(Attribute))
            {
                numAttributes++;
            }
        }

        return numAttributes / numCharacters;
    }

    public float GetKillPercent_Stay(CharacterAttributes Attribute)
    {
        float numCharacters = StayVictims.Count;
        float numAttributes = 0;

        foreach (Character character in StayVictims)
        {
            if (character.GetAttributes().Contains(Attribute))
            {
                numAttributes++;
            }
        }

        return numAttributes / numCharacters;
    }
}
