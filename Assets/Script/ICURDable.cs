using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Action able to
/// Create / Update / Read / Delete
/// interface
/// </summary>
public interface ICURDable
{
    #region Create

    #region Sign
    /// <summary>
    /// 회원가입을 하는 함수
    /// </summary>
    /// <param name="userName">회원가입하려는 유저이름</param>
    /// <param name="password">로그인에 사용될 비밀번호</param>
    /// <returns>회원가입의 성공여부</returns>
    public bool Sign(string userName, string password);
    #endregion

    #endregion

    #region Update

    #region Matching
    /// <summary>
    /// 유저(userName)의 매칭을 시작하는 함수
    /// </summary>
    /// <param name="userName">매칭을 시작할 유저의 이름</param>
    /// <returns>매칭 시작의 성공여부</returns>
    public bool StartMatch(string userName);
    /// <summary>
    /// 로그인 되어있는 유저의 매칭을 시작하는 함수
    /// </summary>
    /// <returns>매칭 시작의 성공여부</returns>
    public bool StartMatch();
    /// <summary>
    /// 유저(userName)의 매칭을 종료하는 함수
    /// </summary>
    /// <param name="userName">매칭을 종료할 유저의 이름</param>
    /// <returns>매칭 종료의 성공여부</returns>
    public bool StopMatch(string userName);
    /// <summary>
    /// 로그인된 유저의 매칭을 종료하는 함수
    /// </summary>
    /// <returns>매칭 종료의 성공여부</returns>
    public bool StopMatch();
    #endregion

    #region Before Game
    /// <summary>
    /// 캐릭터를 설정하는 함수
    /// </summary>
    /// <param name="type">설정할 캐릭터의 타입</param>
    /// <returns>캐릭터 설정의 성공여부</returns>
    public bool SetCharactor(eCHARACTOR_TYPE type);
    /// <summary>
    /// 맵을 설정하는 함수
    /// </summary>
    /// <param name="type">설정할 맵의 타입</param>
    /// <returns>맵 설정의 성공여부</returns>
    public bool SetMap(eMAP_TYPE type);
    /// <summary>
    /// 몇판 몇승을 설정하는 함수
    /// </summary>
    /// <param name="totalCount">전체 판의 수</param>
    /// <returns>설정의 성공여부</returns>
    public bool SetBestOutOfCount(int totalCount);
    #endregion

    #endregion

    #region Read

    #region Login
    /// <summary>
    /// 로그인을 하는 함수
    /// </summary>
    /// <param name="userName">로그인하려는 유저이름</param>
    /// <param name="password">유저의 비밀번호</param>
    /// <returns>로그인의 성공여부</returns>
    public bool Login(string userName, string password);
    #endregion

    #endregion

    #region Delete



    #endregion
}
