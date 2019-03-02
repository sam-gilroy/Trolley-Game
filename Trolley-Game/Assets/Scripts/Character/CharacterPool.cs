using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : Object {
    protected CharacterComponent CharacterPrefab;

    List<CharacterComponent> ActiveObjects = new List<CharacterComponent>();
    Stack<CharacterComponent> RecycledObjects = new Stack<CharacterComponent>();

    public CharacterPool(CharacterComponent CharacterPrefab)
    {
        this.CharacterPrefab = CharacterPrefab;
    }

    public CharacterComponent Spawn(Vector3 position)
    {
        CharacterComponent c = Spawn();
        c.transform.position = position + Vector3.up * 10;
        return c;
    }

    public CharacterComponent Spawn()
    {
        CharacterComponent t = null;

        if (RecycledObjects.Count == 0)
        {
            t = Instantiate(CharacterPrefab) as CharacterComponent;
            t.SetPool(this);
        }
        else
        {
            t = RecycledObjects.Pop();
            t.gameObject.SetActive(true);
            t.transform.parent = null;
        }

        ActiveObjects.Add(t);
        return t;
    }

    public virtual void Recycle(CharacterComponent t)
    {
        t.gameObject.SetActive(false);
        t.transform.parent = CharacterManager.Instance().transform;
        ActiveObjects.Remove(t);
        RecycledObjects.Push(t);
    }

    public void RecallAllCharacters()
    {
        while (ActiveObjects.Count > 0)
        {
            ActiveObjects[0].Recycle();
        }
    }
}
