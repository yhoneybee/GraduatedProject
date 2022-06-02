using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLinker : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Title");
    }
}
