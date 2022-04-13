using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : class
{
    public static T I { get; private set; }

    public virtual void Awake()
    {
        I = GetComponent<T>();
    }

    public void OnDestroy()
    {
        I = null;
    }
}
