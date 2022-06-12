using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SERVER
{
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
        GetAllUserFail,
        GetAllUserSuccess,
        ReadyFail,
        ReadySuccess,
        StartGameFail,
        StartGameSuccess,
        SurrenderGameFail,
        SurrenderGameSuccess,
        WinFail,
        WinSuccess,
        LoseFail,
        LoseSuccess,
        End,
    }

    public abstract class SQL : IDisposable
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
        public abstract SQL GetAllRoom(out List<RoomData> roomData, string where = "");
        public abstract SQL GetAllUser(out List<UserData> userData, string where = "");
        public abstract SQL Ready(string userId);
        public abstract SQL StartGame(string userId);
        public abstract SQL SurrenderGame(string userId);
        public abstract SQL WinGame();
        public abstract SQL LoseGame();
        public abstract void Dispose();
    }
}
