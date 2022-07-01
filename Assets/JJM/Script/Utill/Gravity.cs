using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private float gravity = 0.1f;
    Caric caric;


    // Start is called before the first frame update

    public void AddForce(float forceValue) 
    {
        caric.jumpForce = forceValue;
    }

    void Start()
    {
        caric = GetComponent<Caric>();
    }

    // Update is called once per frame
    void Update()
    {
        caric.jumpForce -= gravity * Time.deltaTime;

        if(caric.rigid.velocity.y != 0) gameObject.transform.Translate(Vector3.up * caric.jumpForce * Time.deltaTime);
    }
}
