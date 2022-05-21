using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public struct WindowComponent
{
    public RectTransform rtrnRootWindow;
    public Button btnClose;
}

public class Window : MonoBehaviour
{
    public WindowComponent windowComponent;
}
