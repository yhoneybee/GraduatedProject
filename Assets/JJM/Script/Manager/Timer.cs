using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : Singleton<Timer>
{   
    public void StartTimer(float _time, System.Action _offTime = null, System.Action _onTime = null)
    {
        restTime = V.worldTime + _time;
        offTime = _offTime;
        onTime = _onTime;
        IsTimeCheck = true;
    }
    public System.Action onTime;
    public System.Action offTime;
    public float restTime;
    public bool IsTimeCheck = false;
    private void Update() 
    {
        if(restTime < V.worldTime && IsTimeCheck)
        {
            if(onTime != null) onTime();
            IsTimeCheck = false;
        }
        else if(restTime > V.worldTime && !IsTimeCheck)
        {
            offTime?.Invoke();
        }
    }
}
