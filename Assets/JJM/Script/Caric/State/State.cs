using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public class Copy : State //복사 드가자~
{
    public override void Enter()
    {

    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
        
    }
}

[System.Serializable]
public abstract class State : MonoBehaviour //상태 베이스
{
    protected CaricAI ai;
    protected float dir;
    public abstract void Enter();
    public abstract void Tick();
    public abstract void Exit();
    public void CaricMove() //캐릭터 움직임
    {
        if (!RayCastCheck())
            transform.Translate(Vector3.right * ai.moveDir * ai.caric.moveSpeed * Time.deltaTime);
    }

    public void StateInit(string playeAnim, CARIC_STATE cs, CharactorState charactorState) //플레이어 정보 받아오기
    {
        ai = GetComponent<CaricAI>();
        dir = (gameObject.transform.localScale.x > 0) ? 1 : -1;
        ai.charactorState = charactorState;

        if (playeAnim == "") return;

        ai.caric.anim.Play(playeAnim); //해당 애니메이션 실행
        ai.cs = cs;
    }

    public bool AABB_Box() //박스 충돌
    {
        var obj = V.FindMyCaric(V.playerNumber);
        float minX, maxX;
        float minY, maxY;

        minX = obj.transform.position.x - (obj.transform.localScale.x / 2);
        maxX = obj.transform.position.x + (obj.transform.localScale.x / 2);

        minY = obj.transform.position.y - (obj.transform.localScale.y / 2);
        maxY = obj.transform.position.y + (obj.transform.localScale.y / 2);

        return (transform.position.x + (transform.localScale.x / 2) >= minX &&
            transform.position.x - (transform.localScale.x / 2) <= maxX &&
            transform.position.y + (transform.localScale.y / 2) >= minY &&
            transform.position.y - (transform.localScale.y / 2) <= maxY);
    }

    public bool RayCastCheck() //플레이어 충돌 처리
    {
        float distance = 1f;

        Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), Vector3.right * dir * distance, new Color(0, 1, 0));

        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), Vector3.right * dir, distance, LayerMask.GetMask("Enemy"));

        return hit.collider;
    }


}
