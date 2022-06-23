using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Network.Instance.onConnect = (v) => 
        {
            if (v)
            {
                SceneManager.LoadScene("Title");
            }
            else
            {
                // Fail Connect
            }
        };
    }
}
