// Luke Mayo 2018
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabbedSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public const string PrefabPath = "Singleton/";

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    protected static T instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static T Instance()
    {
        if (instance == null)
        {
            GameObject SingletonPrefab = Resources.Load(PrefabPath + typeof(T).ToString()) as GameObject;
            instance = Instantiate(SingletonPrefab, Vector3.zero, Quaternion.identity).GetComponent<T>();
            DontDestroyOnLoad(instance.gameObject);
        }
        return instance;
    }

    private void Reset()
    {
    }
}
