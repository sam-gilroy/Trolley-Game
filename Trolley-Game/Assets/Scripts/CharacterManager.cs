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
public class CharacterManager : Singleton<CharacterManager>, ISingleton {
    [SerializeField] CharacterComponent DefaultCharacterPrefab;

    CharacterComponent[] CharacterPrefabs;

    public void Init()
    {
        CharacterPrefabs = Resources.LoadAll<CharacterComponent>("Prefabs/Characters");
        SpawnRandomCharacter();
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

}
