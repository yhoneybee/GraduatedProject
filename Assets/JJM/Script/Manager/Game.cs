using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    //Caric Player;
    // Start is called before the first frame update
    public Caric CreateCaric(Caric caric, string name, int caricnumber, Vector3 pos) 
    {
        var obj = Instantiate(caric, pos, Quaternion.identity);
        obj.name = name;
        obj.caricName = name;
        obj.caricNumber = caricnumber;
        int layer = (V.playerNumber == obj.caricNumber) ? LayerMask.NameToLayer("Player") : LayerMask.NameToLayer("Enemy");
        obj.gameObject.layer = layer;
        obj.bone.gameObject.layer = layer;
        obj.gameObject.transform.localScale = new Vector3(((obj.caricNumber == 0) ? 1 : -1), gameObject.transform.localScale.y, gameObject.transform.localScale.z);


        return obj;
    }
}
