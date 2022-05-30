using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingame : SceneBase //인게임 씬
{
    [Header("=====Ingame Scene Class=====")]
    public string nowInputKey; //입력 된 키

    public float maxInputTime; //타임 체크 변수
    private const float inputTime = 0.25f; //타임 벨류
    // Start is called before the first frame update
    public override void SceneStart()
    {
        maxInputTime = V.worldTime + inputTime;
    }

    public override void ScenePlaying()
    {
        CommandCheck();
    }

    public override void SceneEnd()
    {

    }

    public void CommandCheck() 
    {
        if (maxInputTime < V.worldTime)//커맨드 초기화
        {
            nowInputKey = "";
            maxInputTime = V.worldTime + inputTime;
        }

        nowInputKey += Input.inputString;

        Debug.Log("커맨드 추가 : " + nowInputKey);

        switch (nowInputKey) 
        {
            
        }

    }
}