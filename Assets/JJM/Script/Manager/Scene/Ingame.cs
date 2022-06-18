using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ingame : SceneBase<Ingame> //인게임 씬
{
    [Header("=====Ingame Scene Class=====")]
    public Transform[] spawnPoints; //생성 포인트
    public Caric player;
    public Caric enemy;

    public override void SceneStart()
    {
        player = Instantiate(player, spawnPoints[0].position, Quaternion.identity);
        enemy = Instantiate(enemy, spawnPoints[1].position, Quaternion.identity);
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