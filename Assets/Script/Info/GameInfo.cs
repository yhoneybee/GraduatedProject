using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// �ΰ��� �÷��̾� �¸� Ƚ�� ����
/// </summary>
[Serializable]
public struct BestOfCount
{
    public int user1;
    public int user2;
}

/// <summary>
/// ��Ī �� ���ӿ� ���� ������ �����ϴ� Ŭ����
/// </summary>
[Serializable]
public class GameInfo
{
    /// <summary>
    /// ���������� �����ϴ� ������
    /// </summary>
    /// <param name="mapType">���ӿ��� ����Ǵ� ���� Ÿ��</param>
    /// <param name="user1">������ �÷����ϴ� ����1�� ����</param>
    /// <param name="user2">������ �÷����ϴ� ����2�� ����</param>
    public GameInfo(eMAP_TYPE mapType, UserInfo user1, UserInfo user2)
    {
        this.mapType = mapType;
        this.user1 = user1;
        this.user2 = user2;
        id = K.SHA256($"{mapType}{user1.id}{user1.name}{user2.id}{user2.name}{DateTime.Now}");
    }

    public string id;

    UserInfo user1;
    UserInfo user2;

    public eMAP_TYPE mapType;
}
