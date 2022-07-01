using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MyPacket;

public class Ingame : SceneBase<Ingame> //인게임 씬
{
    [Header("=====Ingame Scene Class=====")]
    public Transform[] spawnPoints; //생성 포인트

    public Caric player1;
    public Caric player2;
    public Dictionary<CharactorType, Caric> charactors = new Dictionary<CharactorType, Caric>();
    public Caric[] players;

    public event EventHandler onStart;

    public override void SceneAwake()
    {
        AddCharactors();

        Caric player1_Charactor = charactors[CharactorType.Samdae];
        Caric player2_Charactor = charactors[CharactorType.Samdae];

        player1 = CreateCaric(player1_Charactor, player1_Charactor.name, 0, spawnPoints[0].position);
        player2 = CreateCaric(player2_Charactor, player2_Charactor.name, 1, spawnPoints[1].position);
    }

    public override void SceneStart()
    {
        onStart(this, EventArgs.Empty); //이벤트 호출
    }
    public override void SceneEnter()
    {
    }
 
    public override void ScenePlaying()
    {
    }

    public override void SceneEnd()
    {

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
}