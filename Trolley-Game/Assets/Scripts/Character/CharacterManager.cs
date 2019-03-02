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
public class CharacterManager : Singleton<CharacterManager>{
    [SerializeField] CharacterComponent DefaultCharacterPrefab;

    CharacterComponent[] CharacterPrefabs;
    
    Dictionary<CharacterComponent, CharacterPool> CharacterPools = new Dictionary<CharacterComponent, CharacterPool>();

    protected override void Awake()
    {
        base.Awake();

        CharacterPrefabs = Resources.LoadAll<CharacterComponent>("Prefabs/Characters");

        foreach(CharacterComponent c in CharacterPrefabs)
        {
            CharacterPools.Add(c, new CharacterPool(c));
        }
    }

    public void SpawnRandomCharacter()
    {
        int r = Random.Range(0, CharacterPrefabs.Length);
        Spawn(CharacterPrefabs[r]);
    }

    public void SpawnRandomCharacter(Transform transform)
    {
        int r = Random.Range(0, CharacterPrefabs.Length);
        CharacterComponent c = Spawn(CharacterPrefabs[r]);
        c.transform.position = transform.position;
    }

    public void SpawnScenario(Scenario scenario)
    {
        for (int i=0; i<scenario.SwitchCharacters.Length; i++)
        {
            Spawn(scenario.SwitchCharacters[i], transform.position + Vector3.forward * i);
        }

        for (int i=0; i<scenario.StayCharacters.Length; i++)
        {
            Spawn(scenario.StayCharacters[i], transform.position + Vector3.right * i + Vector3.up  * 1);
        }
    }

    public CharacterComponent Spawn(CharacterComponent character, Vector3 position)
    {
        return CharacterPools[character].Spawn(position);
    }

    public CharacterComponent Spawn(CharacterComponent Prefab)
    {
        return CharacterPools[Prefab].Spawn();
    }

    public void RecallAllCharacters()
    {
        foreach(KeyValuePair<CharacterComponent, CharacterPool> pool in CharacterPools)
        {
            pool.Value.RecallAllCharacters();
        }
    }
}

