using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using MyPacket;
using System;

public class LoadingManager : MonoBehaviour
{
    public Image imgFade;
    public Button btnConnect;
    public Text txtResult;

    private void OnEnable()
    {
        Network.Instance.onConnect = ConnectSuccess;
    }

    private void ConnectSuccess()
    {
        txtResult.DOKill();
        txtResult.DOText("접속 성공!", 1).onComplete = () =>
        {
            imgFade.DOFade(1, 1).onComplete = () =>
            {
                SceneManager.LoadScene("Title");
            };
        };
    }

    void Start()
    {
        imgFade.DOFade(0, 1);

        btnConnect.onClick.AddListener(TryConnect);

        txtResult.text = string.Empty;
    }

    private void TryConnect()
    {
        StopAllCoroutines();
        StartCoroutine(ECheckTimeOut());
    }

    IEnumerator ECheckTimeOut()
    {
        float time = 0;

        txtResult.text = string.Empty;
        txtResult.DOKill();
        txtResult.DOText("연결중...", 2).SetLoops(-1, LoopType.Restart);

        while (time <= 32)
        {
            time += Time.deltaTime;
            if (Network.Instance.IsConnect)
            {
                Network.Instance.StartReceive();

                REQ req = new REQ();
                req.what = "Connected";
                K.Send(PacketType.REQ_CONNECTED, req);
                yield break;
            }
            else
            {
                Network.Instance.Connect();
            }
            yield return null;
        }

        txtResult.DOKill();
        txtResult.DOText("시간 초과", 2);
    }
}
