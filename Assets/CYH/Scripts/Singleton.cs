using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : class
{
    public static T Instance { get; private set; } = null;

    public virtual void OnEnable()
    {
        Instance = GetComponent<T>();
    }

    public virtual void OnDestroy()
    {
        Instance = null;
    }
}
