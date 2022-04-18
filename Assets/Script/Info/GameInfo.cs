using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// 인게임 플레이어 승리 횟수 정보
/// </summary>
[Serializable]
public struct BestOfCount
{
    public int user1;
    public int user2;
}

/// <summary>
/// 매칭 후 게임에 대한 정보를 관리하는 클래스
/// </summary>
[Serializable]
public class GameInfo
{
    /// <summary>
    /// 게임정보를 생성하는 생성자
    /// </summary>
    /// <param name="mapType">게임에서 진행되는 맵의 타입</param>
    /// <param name="user1">게임을 플레이하는 유저의 정보</param>
    /// <param name="user2">상대 유저의 정보</param>
    public GameInfo(eMAP_TYPE mapType, UserInfo user1, UserInfo user2)
    {
        this.mapType = mapType;
        my = user1;
        other = user2;
        id = K.SHA256($"{mapType}{user1.id}{user1.name}{user2.id}{user2.name}{DateTime.Now}");
    }

    public string id;

    UserInfo my;
    UserInfo other;

    public eMAP_TYPE mapType;
}
