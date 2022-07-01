using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : Singleton<UI>
{
    public GameObject[] playerInfo;
    public Sprite[] playerFace;

    Dictionary<string, Sprite> playerFaceParis = new Dictionary<string, Sprite>();
    // Start is called before the first frame update
    private void Awake()
    {
        Ingame.Instance.onStart += new System.EventHandler(PlayerInfoInit);
        playerFaceParis.Add("SamDae", playerFace[0]);
        playerFaceParis.Add("Kanzi", playerFace[1]);
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

            count++;
        }
    }

    public void HpSliderValueChange(float value, int number) 
    {
        HpBarSlider hpBarSlider = playerInfo[number].transform.Find("HpBar").GetComponent<HpBarSlider>();
        hpBarSlider.OnDamage(value);
    }
}
