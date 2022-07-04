using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class V : MonoBehaviour //공용 변수 클래스
{
    public static float worldTime = 0; //게임 시간

    public static GameObject MainCanvas = null;

    public static int playerNumber;

    public static bool IsStop = false;
    // Start is called before the first frame update
    public static void Awake()
    {
        MainCanvas = GameObject.Find("MainCanvas");
        
        Debug.Log("V Awake!");
    }

    public static void Start()
    {
        Debug.Log("V Start!");

        Debug.Log("playerNumber : " + playerNumber);
    }

    // Update is called once per frame
    public static void Update()
    {
        worldTime = Time.time; //게임 시간 기록
    }
}