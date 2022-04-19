using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

[Serializable]
public struct MakeMatchUI
{
    public TextMeshProUGUI txtMakeMatchBtn;
    public TextMeshProUGUI txtMatching;
    public bool isMatching;
}

[Serializable]
public struct ReadyUI
{
    public GameObject goParent;
    public Image imgReadyTimeRotate;
}

public class TestMatchManager : Singleton<TestMatchManager>
{
    public MakeMatchUI makeMatchUI;
    public ReadyUI readyUI;

    private void Start()
    {
        StartCoroutine(EDoingText("¸ÅÄª Ã£´Â Áß"));
    }

    public void Logout()
    {
        SceneManager.LoadScene(0);
    }

    public void MakeMatch()
    {
        if (CURDFactory.GetCURDable(out var curd))
        {
            makeMatchUI.isMatching = !makeMatchUI.isMatching;

            if (makeMatchUI.isMatching)
            {
                if (curd.StartMatch())
                {
                    makeMatchUI.txtMatching.gameObject.SetActive(true);
                    makeMatchUI.txtMakeMatchBtn.text = $"¸ÅÄª Áß´Ü";
                }
            }
            else
            {
                if (curd.StopMatch())
                {
                    makeMatchUI.txtMatching.gameObject.SetActive(false);
                    makeMatchUI.txtMakeMatchBtn.text = $"¸ÅÄª Ã£±â";
                }
            }
        }
    }

    private IEnumerator EDoingText(string originText)
    {
        int dot = 0;
        while (true)
        {
            yield return null;

            if (!makeMatchUI.txtMatching.gameObject.activeSelf)
            {
                dot = 0;
                continue;
            }

            string text = "";

            for (int i = 0; i < dot; i++)
                text += ".";

            makeMatchUI.txtMatching.text = $"{originText}{text}";

            ++dot;

            dot %= 4;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
