using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
using System.Linq;

public class SFirebase : ICURDable
{
    DatabaseReference database;

    public bool EndGame(string gameId)
    {
        throw new System.NotImplementedException();
    }

    public bool EndGame(GameInfo gameInfo)
    {
        return EndGame(gameInfo.id);
    }

    public bool Initialize()
    {
        database = FirebaseDatabase.DefaultInstance.RootReference;

        if (database == null) return false;

        database.Child("matching").ChildAdded += (o, e) =>
        {
            Debug.Log($"MATCHING");
        };

        return true;
    }

    public bool Login(string userId, string password)
    {
        password = K.SHA256(password);

        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                var ss = task.Result;
                foreach (var item in ss.Children)
                {
                    if (item.Key != userId) continue;

                    var dic = item.Value as IDictionary;

                    if (dic["password"].ToString() != password) continue;

                    K.loginedUser = new UserInfo(dic["id"].ToString(), dic["name"].ToString(), dic["password"].ToString());

                    SceneManager.LoadScene(1);
                }
            }
        });

        return true;
    }

    public bool ReadyMatch()
    {
        return true;
    }

    public bool SetBestOutOfCount(int count)
    {
        throw new System.NotImplementedException();
    }

    public bool SetCharactor(eCHARACTOR_TYPE charactorType)
    {
        throw new System.NotImplementedException();
    }

    public bool SetMap(eMAP_TYPE mapType)
    {
        throw new System.NotImplementedException();
    }

    public bool Sign(string userId, string userName, string userPassword, string confirmUserPassword)
    {
        userPassword = K.SHA256(userPassword);
        confirmUserPassword = K.SHA256(confirmUserPassword);

        if (userPassword != confirmUserPassword) return false;

        UserInfo userInfo = new UserInfo(userId, userName, userPassword);

        string json = JsonUtility.ToJson(userInfo, true);

        Debug.Log($"to json result : {json}");

        database.Child("users").Child(userId).SetRawJsonValueAsync(json);

        return true;
    }

    public bool StartGame(eMAP_TYPE mapType)
    {
        return true;
    }

    public bool StartMatch()
    {
        MakeMatchingUserInfo makeMatchingUserInfo = new MakeMatchingUserInfo(false);

        string json = JsonUtility.ToJson(makeMatchingUserInfo, true);

        Debug.Log($"to json result : {json}");

        database.Child("matching").Child(K.loginedUser.id).SetRawJsonValueAsync(json);

        return true;
    }

    public bool StopMatch()
    {
        database.Child("matching").Child(K.loginedUser.id).RemoveValueAsync();

        return true;
    }
}
