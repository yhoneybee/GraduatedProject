using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : Singleton<Effect>
{
    public Dictionary<string, GameObject> effects = new Dictionary<string, GameObject>();

    public List<GameObject> effectList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var effect in effectList)
        {
            effects.Add(effect.name, effect);
        }
    }

    public GameObject GetEffect(string name, Vector3 pos) 
    { 
        return Instantiate(effects[name], pos, Quaternion.identity);
    }
}
