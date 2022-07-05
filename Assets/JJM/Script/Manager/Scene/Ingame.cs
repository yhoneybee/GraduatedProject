using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MyPacket;

public class Ingame : SceneBase<Ingame> //인게임 씬
{
    [Header("=====Ingame Scene Class=====")]
    public Transform[] spawnPoints; //생성 포인트

    public Dictionary<CharactorType, Caric> charactors = new Dictionary<CharactorType, Caric>();
    public Caric[] players;

    public CameraTargetGroup cameraTarget;

    public event EventHandler onStartEvent; //스타트 이벤트

    public override void SceneAwake()
    {
        AddCharactors();

        Caric player1_Charactor = charactors[K.player1Type];
        Caric player2_Charactor = charactors[K.player2Type];

        players[0] = CreateCaric(player1_Charactor, player1_Charactor.name, 0, spawnPoints[0].position);
        players[1] = CreateCaric(player2_Charactor, player2_Charactor.name, 1, spawnPoints[1].position);

        V.IsStop = true;

        cameraTarget.OnCamera(cameraTarget.playerCamera[2].gameObject);
    }

    public override void SceneStart()
    {
        onStartEvent(this, EventArgs.Empty); //이벤트 호출

        SoundManager.Instance.PlayIngame();
    }
    public override void SceneEnter()
    {
        StartCoroutine(StartProduction());
    }
 
    public override void ScenePlaying()
    {
    }

    public override void SceneEnd()
    {

    }

    public IEnumerator StartProduction() 
    {
        cameraTarget.OnCamera(cameraTarget.playerCamera[0].gameObject);

        yield return new WaitForSeconds(2f);

        players[0].PlaySound(eCHARACTOR_SOUND_TYPE.Start);

        yield return new WaitForSeconds(3.5f);

        cameraTarget.OnCamera(cameraTarget.playerCamera[1].gameObject);

        yield return new WaitForSeconds(2f);

        players[1].PlaySound(eCHARACTOR_SOUND_TYPE.Start);

        yield return new WaitForSeconds(3.5f);

        cameraTarget.OnCamera(cameraTarget.playerCamera[2].gameObject);

        yield return new WaitForSeconds(2f);

        UI.Instance.Start.SetActive(true);
        UI.Instance.Ready.SetActive(true);
    }

    public void OnGameStart() 
    {
        V.IsStop = false;
    }

    public void OnGameEnd() 
    {
        StartCoroutine(GameEndCoroutine());
    }

    public IEnumerator GameEndCoroutine() 
    {
        yield return new WaitForSeconds(3f);

        Debug.Log("GameEnd!!!!!!!!!!!!!!");

        foreach (var caric in players)
        {
            if(caric.caricNumber == V.playerNumber) 
            {
                switch (caric.Hp)
                {
                    case 0:
                        K.Lose();
                        Debug.Log("Lose");
                        break;
                    default:
                        K.Win();
                        Debug.Log("WIn");
                        break;
                }
            }
        }
    }

    public void AddCharactors() 
    {
        foreach (var caric in players)
        {
            charactors.Add(caric.charactorType, caric);
        }
    }

    public Caric CreateCaric(Caric caric, string name, int caricnumber, Vector3 pos)
    {
        var obj = Instantiate(caric, pos, Quaternion.identity);
        obj.name = name;
        obj.caricName = name;
        obj.caricNumber = caricnumber;
        int layer = (V.playerNumber == obj.caricNumber) ? LayerMask.NameToLayer("Player") : LayerMask.NameToLayer("Enemy");
        obj.gameObject.layer = layer;
        obj.bone.gameObject.layer = layer;
        obj.gameObject.transform.localScale = new Vector3(((obj.caricNumber == 0) ? 1 : -1), gameObject.transform.localScale.y, gameObject.transform.localScale.z);


        return obj;
    }

    public void OnPlayGong() 
    {
        SoundManager.Instance.PlayGong();
    }
}