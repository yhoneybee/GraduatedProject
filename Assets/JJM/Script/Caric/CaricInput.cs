using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaricInput : MonoBehaviour //캐릭터 키 입력
{
    CaricBase caricBase;

    // Start is called before the first frame update
    void Start()
    {
        if(!caricBase) caricBase = GetComponent<CaricBase>();
    }

    // Update is called once per frame
    void Update()
    {
        CaricInputKey();
    }

    public void CaricInputKey() //키 입력
    {   
        float h = V.GetAxis("Horizontal"); //좌우
        
    }
}
