using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SERVER
{
    public interface IInitilizerable
    {
        public SQL Initilize();
    }

    public interface ILoginOutSignable
    {
        public SQL Login(string id, string pw);
        public SQL Logout();
        public SQL Sign(string id, string pw, string pw2);
    }

    public interface ICreateEnterQuitRoomable
    {
        public SQL CreateRoom(string roomName = "");
        public SQL EnterRoom(string roomName);
        public SQL QuitRoom(string roomName);
        public SQL GetAllRoom(out List<RoomData> roomData);
    }

    public interface IIngameable
    {
        public SQL Ready(string userId);
        public SQL StartGame(string userId);
        public SQL SurrenderGame(string userId);
        public SQL WinGame();
        public SQL LoseGame();
    }

    public interface IAll : IInitilizerable, ILoginOutSignable, ICreateEnterQuitRoomable
    {

    }

    public enum CallbackType
    {
        CreateRoomFail,
        CreateRoomSuccess,
        EnterRoomFail,
        EnterRoomSuccess,
        InitilizeFail,
        InitilizeSuccess,
        LoginFail,
        LoginSuccess,
        LogoutFail,
        LogoutSuccess,
        QuitRoomFail,
        QuitRoomSuccess,
        SignFail,
        SignSuccess,
        GetAllRoomFail,
        GetAllRoomSuccess,
        ReadyFail,
        ReadySuccess,
        StartGameFail,
        StartGameSuccess,
        SurrenderGameFail,
        SurrenderGameSuccess,
        FinishedGameFail,
        FinishedGameSuccess,
        End,
    }

    public abstract class SQL : IAll
    {
        Action[] callbacks = new Action[((int)CallbackType.End)];

        public void Call(CallbackType callbackType) => callbacks[((int)callbackType)]();

        public SQL SetListener(CallbackType callbackType, Action callback)
        {
            callbacks[((int)callbackType)] = callback;
            return this;
        }

        public SQL AddListener(CallbackType callbackType, Action callback)
        {
            callbacks[((int)callbackType)] += callback;
            return this;
        }

        public SQL RemoveListener(CallbackType callbackType, Action callback)
        {
            callbacks[((int)callbackType)] -= callback;
            return this;
        }

        public abstract SQL CreateRoom(string roomName = "");
        public abstract SQL EnterRoom(string roomName);
        public abstract SQL Initilize();
        public abstract SQL Login(string id, string pw);
        public abstract SQL Logout();
        public abstract SQL QuitRoom(string roomName);
        public abstract SQL Sign(string id, string pw, string pw2);
        public abstract SQL GetAllRoom(out List<RoomData> roomData);
    }
}
