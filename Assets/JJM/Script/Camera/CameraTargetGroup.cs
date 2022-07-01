using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTargetGroup : MonoBehaviour //카메라 타겟 그룹 클래스
{
    public CinemachineTargetGroup cinemachineTargetGroup; //시네머신 타켓 그룹
    // Start is called before the first frame update
    void Awake()
    {
        cinemachineTargetGroup = GetComponent<CinemachineTargetGroup>();

        Ingame.Instance.onStart += new System.EventHandler(SetTargetObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetTargetObject(object sender, System.EventArgs e) //타켓 그룹 오브젝트 설정
    {
        cinemachineTargetGroup.AddMember(Ingame.Instance.player1.transform, 1, 3);
        cinemachineTargetGroup.AddMember(Ingame.Instance.player2.transform, 1, 3);
    }
}
