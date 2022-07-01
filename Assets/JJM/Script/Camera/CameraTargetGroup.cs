using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTargetGroup : MonoBehaviour //ī�޶� Ÿ�� �׷� Ŭ����
{
    public CinemachineTargetGroup cinemachineTargetGroup; //�ó׸ӽ� Ÿ�� �׷�
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

    void SetTargetObject(object sender, System.EventArgs e) //Ÿ�� �׷� ������Ʈ ����
    {
        cinemachineTargetGroup.AddMember(Ingame.Instance.player1.transform, 1, 3);
        cinemachineTargetGroup.AddMember(Ingame.Instance.player2.transform, 1, 3);
    }
}
