using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Action able to
/// Create / Update / Read / Delete
/// interface
/// </summary>
public interface ICURDable
{
    public bool Initialize();

    #region Create

    #region Sign
    /// <summary>
    /// 회원가입을 하는 함수
    /// </summary>
    /// <param name="userId">로그인에 사용될 아이디</param>
    /// <param name="userName">게임에서 사용할 유저이름</param>
    /// <param name="password">로그인에 사용될 비밀번호</param>
    /// <returns>회원가입의 성공여부</returns>
    public bool Sign(string userId, string userName, string userPassword, string confirmUserPassword);
    #endregion

    #region Game
    /// <summary>
    /// 게임을 시작하는 함수
    /// </summary>
    /// <param name="mapType">게임을 시작할 맵</param>
    /// <param name="user1Id">게임을 시작할 유저1의 아이디</param>
    /// <param name="user2Id">게임을 시작할 유저2의 아이디</param>
    /// <returns>게임시작의 성공여부</returns>
    public bool StartGame(eMAP_TYPE mapType, string user1Id, string user2Id);
    /// <summary>
    /// 게임을 시작하는 함수
    /// </summary>
    /// <param name="mapType">게임을 시작할 맵</param>
    /// <param name="user1Info">게임을 시작할 유저1의 정보</param>
    /// <param name="user2Info">게임을 시작할 유저2의 정보</param>
    /// <returns>게임시작의 성공여부</returns>
    public bool StartGame(eMAP_TYPE mapType, UserInfo user1Info, UserInfo user2Info);
    #endregion

    #endregion

    #region Update

    #region Matching
    /// <summary>
    /// 유저(userName)의 매칭을 시작하는 함수
    /// </summary>
    /// <param name="userId">매칭을 시작할 유저의 이름</param>
    /// <returns>매칭 시작의 성공여부</returns>
    public bool StartMatch(string userId);
    /// <summary>
    /// 유저의 매칭을 시작하는 함수
    /// </summary>
    /// <param name="userInfo">매칭을 시작할 유저의 정보</param>
    /// <returns>매칭 시작의 성공여부</returns>
    public bool StartMatch(UserInfo userInfo);
    /// <summary>
    /// 로그인 되어있는 유저의 매칭을 시작하는 함수
    /// </summary>
    /// <returns>매칭 시작의 성공여부</returns>
    public bool StartMatch();
    /// <summary>
    /// 매칭이 잡힌 후 게임 진행을 수락하는 함수
    /// </summary>
    /// <param name="userId">게임을 진행할 유저의 아이디</param>
    /// <returns>게임 진행 수락 여부</returns>
    public bool ReadyMatch(string userId);
    /// <summary>
    /// 매칭이 잡힌 후 게임 진행을 수락하는 함수
    /// </summary>
    /// <param name="userInfo">게임을 진행할 유저의 정보</param>
    /// <returns>게임 진행 수락 여부</returns>
    public bool ReadyMatch(UserInfo userInfo);
    /// <summary>
    /// 매칭이 잡힌 후 게임 진행을 수락하는 함수
    /// </summary>
    /// <returns>게임 진행 수락 여부</returns>
    public bool ReadyMatch();
    /// <summary>
    /// 유저(userName)의 매칭을 종료하는 함수
    /// </summary>
    /// <param name="userId">매칭을 종료할 유저의 이름</param>
    /// <returns>매칭 종료의 성공여부</returns>
    public bool StopMatch(string userId);
    /// <summary>
    /// 유저의 매칭을 종료하는 함수
    /// </summary>
    /// <param name="userInfo">매칭을 종료할 유저의 정보</param>
    /// <returns>매칭 종료의 성공여부</returns>
    public bool StopMatch(UserInfo userInfo);
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
    /// <param name="charactorType">설정할 캐릭터의 타입</param>
    /// <returns>캐릭터 설정의 성공여부</returns>
    public bool SetCharactor(eCHARACTOR_TYPE charactorType);
    /// <summary>
    /// 맵을 설정하는 함수
    /// </summary>
    /// <param name="mapType">설정할 맵의 타입</param>
    /// <returns>맵 설정의 성공여부</returns>
    public bool SetMap(eMAP_TYPE mapType);
    /// <summary>
    /// 몇판 몇승을 설정하는 함수
    /// </summary>
    /// <param name="count">전체 판의 수</param>
    /// <returns>설정의 성공여부</returns>
    public bool SetBestOutOfCount(int count);
    #endregion

    #region After Game

    #endregion

    #endregion

    #region Read

    #region Login
    /// <summary>
    /// 로그인을 하는 함수
    /// </summary>
    /// <param name="userId">로그인하려는 유저 아이디</param>
    /// <param name="password">유저의 비밀번호</param>
    /// <returns>로그인의 성공여부</returns>
    public bool Login(string userId, string password);
    #endregion

    #endregion

    #region Delete

    #region Game
    /// <summary>
    /// 게임을 종료하는 함수
    /// </summary>
    /// <param name="gameId">종료할 게임의 아이디</param>
    /// <returns>게임종료의 성공여부</returns>
    public bool EndGame(string gameId);
    /// <summary>
    /// 게임을 종료하는 함수
    /// </summary>
    /// <param name="gameInfo">종료할 게임의 정보</param>
    /// <returns>게임종료의 성공여부</returns>
    public bool EndGame(GameInfo gameInfo);
    #endregion

    #endregion
}
