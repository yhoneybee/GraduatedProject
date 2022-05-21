using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        K.GetDB(DB.MySQL).Sign("kkulbeol", "Rnfqjf2671!@#", "Rnfqjf2671!@#").onSignSuccess += () => { print("회원가입 성공"); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
