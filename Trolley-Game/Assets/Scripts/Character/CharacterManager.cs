// Luke Mayo, 2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJamTools;

/// <summary>
/// What are the responsibilities of the character manager?
/// Does it need stratified pools? ye prolly
/// 
/// It needs to have a collection of spawn points
/// Needs to be able to spawn certain types of characters
/// 
/// Probably needs a tiered object pool a la how the ParticleManger does it
/// </summary>
public class CharacterManager : Singleton<CharacterManager> {
    [SerializeField] CharacterComponent DefaultCharacterPrefab;

    CharacterComponent[] CharacterPrefabs;

    protected override void Awake()
    {
        base.Awake();

        CharacterPrefabs = Resources.LoadAll<CharacterComponent>("Prefabs/Characters");
    }

    public void SpawnRandomCharacter()
    {
        int r = Random.Range(0, CharacterPrefabs.Length);
        Instantiate(CharacterPrefabs[r], transform.position, Quaternion.identity);
    }

    public void SpawnRandomCharacter(Transform transform)
    {
        int r = Random.Range(0, CharacterPrefabs.Length);
        Instantiate(CharacterPrefabs[r], transform.position, Quaternion.identity);
    }

    public void SpawnScenario(Scenario scenario)
    {
        for (int i=0; i<scenario.SwitchCharacters.Length; i++)
        {
            SpawnCharacter(scenario.SwitchCharacters[i], transform.position + Vector3.forward * i);
        }

        for (int i=0; i<scenario.StayCharacters.Length; i++)
        {
            SpawnCharacter(scenario.StayCharacters[i], transform.position + Vector3.right * i + Vector3.up  * 1);
        }
    }

    public void SpawnCharacter(CharacterComponent character, Vector3 position)
    {
        Instantiate(character.gameObject, position + Vector3.up * 10, Quaternion.identity);
    }
}
