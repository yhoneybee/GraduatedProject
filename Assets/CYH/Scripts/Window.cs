using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    public RectTransform rtrnRootWindow;
    public GameObject goRootWindow => rtrnRootWindow.gameObject;

    public Button btnClose;

    public virtual void Start()
    {
        btnClose.onClick.AddListener(Close);
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Close();
    }

    public virtual void Open()
    {
        goRootWindow.SetActive(true);
    }

    public virtual void Close()
    {
        goRootWindow.SetActive(false);
    }
}
