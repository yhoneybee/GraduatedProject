using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class V : MonoBehaviour //공용 스태틱 클래스
{
    public static float worldTime = 0;

    // Start is called before the first frame update
    public static void Start()
    {
        
    }

    // Update is called once per frame
    public static void Update()
    {
        worldTime = Time.time; //게임 시간 기록
    }
}
