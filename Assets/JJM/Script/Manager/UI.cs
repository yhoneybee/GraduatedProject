using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Singleton<UI>
{
    public HpBarSlider[] hpBarSlider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HpSliderValueChange(float value, int number) 
    {
        hpBarSlider[number].OnDamage(value);
    }
}
