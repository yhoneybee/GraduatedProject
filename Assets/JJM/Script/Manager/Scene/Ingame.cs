using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ingame : SceneBase<Ingame> //인게임 씬
{
    [Header("=====Ingame Scene Class=====")]
    public Transform[] spawnPoints; //생성 포인트
    public int playerNumber;
    public Caric[] players = new Caric[2];

    public override void SceneAwake()
    {
        
    }

    public override void SceneStart()
    {
        players[0] = Game.Instance.CreateCaric(players[0], players[0].name, 0, spawnPoints[0].position);
        players[1] = Game.Instance.CreateCaric(players[1], players[1].name, 1, spawnPoints[1].position);
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
}