using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleLinker : MonoBehaviour
{
    public Button btnQuit;

    void Start()
    {
        btnQuit.onClick.AddListener(() => 
        { 
            //K.QuitGame();
            K.Logout();
        });
    }
}
