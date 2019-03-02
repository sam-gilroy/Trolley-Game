// Luke Mayo, 2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour {
    [SerializeField] List<CharacterAttributes> Attributes;

    new Rigidbody rigidbody;

    CharacterPool characterPool = null;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public Character GetCharacter()
    {
        return new Character(Attributes);
    }

    public void SetCharacter(Character character)
    {
        Attributes = character.GetAttributes();
    }

    public virtual void Spawn()
    {
    }

    public virtual void Recycle()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        characterPool.Recycle(this);
    }

    public void SetPool(CharacterPool pool)
    {
        this.characterPool = pool;
    }
}
