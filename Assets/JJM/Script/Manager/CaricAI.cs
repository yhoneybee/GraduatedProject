using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaricAI : MonoBehaviour //캐릭터 상태 관리 클래스
{
    public State state;
    // Start is called before the first frame update
    void Start()
    {   
        if(state == null) ChangeState(gameObject.AddComponent<Idle>());
    }   

    // Update is called once per frame
    void Update()
    {
  
       

    }

    public void ChangeState(State newState) //상태 변경
    {
        if(state != null)
        {
            state.Exit(); //현재 상태 종료
            Destroy(state);
        } 
        
        state = newState;
        state.Enter(); //새로운 상태 시작
    }
}
