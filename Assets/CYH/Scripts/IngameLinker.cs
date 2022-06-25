using MyPacket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameLinker : MonoBehaviour
{
    public GameObject goOwn;
    public GameObject goOther;
    public float speed = 5;

    private void Start()
    {
        Network.Instance.gamePackHandler.RES_Charactor = (packet) =>
        {
            var res = packet.GetPacket<REQ_RES_Charactor>();
        };
    }

    private void Update()
    {
        REQ_RES_Charactor req = new REQ_RES_Charactor();
        req.posX = goOwn.transform.position.x;

        K.PositionUpdate(req);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        goOwn.transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);
    }
}
