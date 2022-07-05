using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : Singleton<UI>
{
    public GameObject[] playerInfo;
    public Sprite[] playerFace;

    public GameObject Ready;
    public GameObject Start;
    public GameObject GameEnd;

    Dictionary<string, Sprite> playerFaceParis = new Dictionary<string, Sprite>();
    // Start is called before the first frame update
    private void Awake()
    {
        Ingame.Instance.onStartEvent += new System.EventHandler(PlayerInfoInit);
        playerFaceParis.Add("»ï´ë", playerFace[0]);
        playerFaceParis.Add("Ä­Áö", playerFace[1]);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerInfoInit(object sender, System.EventArgs e) 
    {
        int count = 0;

        foreach(var Info in playerInfo) 
        {
            Text playerName = Info.transform.Find("Name").transform.Find("Text").GetComponent<Text>();
            playerName.text = Ingame.Instance.players[count].name.ToUpper();

            Image faceImage = Info.transform.Find("Face").transform.Find("Face_Img").GetComponent<Image>();
            faceImage.sprite = playerFaceParis[Ingame.Instance.players[count].name];

            Text userName = Info.transform.Find("UserName").transform.Find("Text").GetComponent<Text>();
            userName.text = (count == 0) ? K.player1.id : K.player2.id;


            count++;
        }
    }

    public void HpSliderValueChange(float value, int number) 
    {
        HpBarSlider hpBarSlider = playerInfo[number].transform.Find("HpBar").GetComponent<HpBarSlider>();
        hpBarSlider.OnDamage(value);
    }

    public void OnGameEnd() 
    {
        GameEnd.SetActive(true);
    }
}
