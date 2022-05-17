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
        public SQL CreateRoom();
        public SQL EnterRoom();
        public SQL QuitRoom();
    }

    public interface IAll : IInitilizerable, ILoginOutSignable, ICreateEnterQuitRoomable
    {

    }

    public abstract class SQL : IAll
    {
        public Action onCreateRoomFail;
        public Action onCreateRoomSuccess;

        public Action onEnterRoomFail;
        public Action onEnterRoomSuccess;

        public Action onInitilizeFail;
        public Action onInitilizeSuccess;

        public Action onLoginFail;
        public Action onLoginSuccess;

        public Action onLogoutFail;
        public Action onLogoutSuccess;

        public Action onQuitRoomFail;
        public Action onQuitRoomSuccess;

        public Action onSignFail;
        public Action onSignSuccess;

        public abstract SQL CreateRoom();
        public abstract SQL EnterRoom();
        public abstract SQL Initilize();
        public abstract SQL Login(string id, string pw);
        public abstract SQL Logout();
        public abstract SQL QuitRoom();
        public abstract SQL Sign(string id, string pw, string pw2);
    }
}
