using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private float gravity = 9.8f;

    Caric caric;
    // Start is called before the first frame update
    void Start()
    {
        caric = GetComponent<Caric>();
    }

    // Update is called once per frame
    void Update()
    {
        caric.jumpForce -= gravity * Time.deltaTime;

        if(gameObject.transform.position.y <= V.GROUND_MIN_Y) 
        {
            gameObject.transform.position = new Vector2(transform.position.x, V.GROUND_MIN_Y);
        }
        else 
        {
            gameObject.transform.Translate(Vector3.up * caric.jumpForce * Time.deltaTime);
        }
    }
}
