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
    /// <param name="user1">������ �÷����ϴ� ������ ����</param>
    /// <param name="user2">��� ������ ����</param>
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
