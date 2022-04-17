using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 유저의 전적을 관리하는 구조체
/// </summary>
[Serializable]
public struct UserRecordInfo
{
    public int win;
    public int lose;
}

/// <summary>
/// 유저의 정보를 관리하는 클래스
/// </summary>
[Serializable]
public class UserInfo
{
    public UserInfo(string id, string name, string password)
    {
        this.id = id;
        this.name = name;
        this.password = password;
    }

    public string id;
    public string name;
    public string password;

    public UserRecordInfo userRecordInfo;

    public eCHARACTOR_TYPE charactorType;
}
