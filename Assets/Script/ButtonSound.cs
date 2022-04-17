using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public List<Button> buttons;

    private void Start()
    {
        foreach (var btn in buttons)
        {
            btn.onClick.AddListener(() => 
            {
            });
        }
    }
}
