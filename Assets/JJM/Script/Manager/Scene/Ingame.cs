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
        foreach(var caric in players) 
        {
            charactors.Add(caric.charactorType, caric);
        }
    }

    public override void SceneStart()
    {
        Caric player1_Charactor = charactors[CharactorType.Samdae];
        Caric player2_Charactor = charactors[CharactorType.Samdae];

        player1 = Game.Instance.CreateCaric(player1_Charactor, player1_Charactor.name, 0, spawnPoints[0].position);
        player2 = Game.Instance.CreateCaric(player2_Charactor, player2_Charactor.name, 1, spawnPoints[1].position);
    }
    public override void SceneEnter()
    {
        onStart(this, EventArgs.Empty); //이벤트 호출
    }
 
    public override void ScenePlaying()
    {
    }

    public override void SceneEnd()
    {

    }
}