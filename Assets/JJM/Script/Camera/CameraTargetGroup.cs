using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTargetGroup : MonoBehaviour //ī�޶� Ÿ�� �׷� Ŭ����
{
    public CinemachineTargetGroup cinemachineTargetGroup; //�ó׸ӽ� Ÿ�� �׷�
    public CinemachineVirtualCamera[] playerCamera;
    public CinemachineBrain cinemachineBrain;
    // Start is called before the first frame update
    void Awake()
    {
        cinemachineTargetGroup = GetComponent<CinemachineTargetGroup>();

        Ingame.Instance.onStartEvent += new System.EventHandler(SetTargetObject);

        //cinemachineBrain.ActiveBlend;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCamera(GameObject cam) 
    {
        cam.SetActive(false);
        cam.SetActive(true);
    }

    void SetTargetObject(object sender, System.EventArgs e) //Ÿ�� �׷� ������Ʈ ����
    {
        int count = 0;

        foreach(var player in Ingame.Instance.players) 
        {
            cinemachineTargetGroup.AddMember(player.transform, 1, 3);
            playerCamera[count].Follow = Ingame.Instance.players[count].transform;

            count++;
        }   
    }
}
