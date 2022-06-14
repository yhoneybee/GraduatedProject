using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestRoomData : MonoBehaviour
{
    public RectTransform rtrnContent;
    public RoomViewer goRoomViewerOrigin;
    public Text txtLeftTime;

    List<RoomViewer> roomViewers = new List<RoomViewer>();

    public float leftTime;
    readonly float waitTime = 60;

    private void Start()
    {
        StartCoroutine(ERefresh());
    }

    public void Refresh()
    {
        leftTime = waitTime;

        //List<RoomData> list;
        //K.GetDB().SetListener(SERVER.CallbackType.GetAllRoomFail, () =>
        //{
        //    print("Load Rooms Fail");
        //}).SetListener(SERVER.CallbackType.GetAllRoomSuccess, () =>
        //{
        //    print("Load Rooms Success");
        //}).GetAllRoom(out list);

        //int minus = roomViewers.Count - list.Count;

        //for (int i = 0; i < minus; i++)
        //{
        //    roomViewers[i + list.Count].gameObject.SetActive(false);
        //}

        //for (int i = 0; i < list.Count; i++)
        //{
        //    RoomData roomData = new RoomData { name = list[i].name, player1 = list[i].player1, player2 = list[i].player2 };

        //    if (roomViewers.Count > i)
        //    {
        //        roomViewers[i].gameObject.SetActive(true);
        //        roomViewers[i].RoomData = roomData;
        //    }
        //    else
        //    {
        //        var roomViewer = Instantiate(goRoomViewerOrigin, rtrnContent);
        //        roomViewer.RoomData = roomData;
        //        roomViewers.Add(roomViewer);
        //    }
        //}
    }

    public IEnumerator ERefresh()
    {
        while (true)
        {
            if (0 < leftTime)
            {
                leftTime -= Time.deltaTime;
            }
            else
            {
                Refresh();
            }
            txtLeftTime.text = $"refresh time : {((int)leftTime)}";
            yield return null;
        }
    }
}
