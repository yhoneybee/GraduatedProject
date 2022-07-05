using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public Transform head;
    public Transform body;
    public Transform foot;
    
    // Start is called before the first frame update
    void Start()
    {
        head = transform.Find("Head");
        body = transform.Find("Body");
        foot = transform.Find("Foot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
