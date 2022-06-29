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
        player1 = Game.Instance.CreateCaric(charactors[K.player1Type], charactors[K.player1Type].name, 0, spawnPoints[0].position);
        player2 = Game.Instance.CreateCaric(charactors[K.player2Type], charactors[K.player2Type].name, 1, spawnPoints[1].position);
        
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