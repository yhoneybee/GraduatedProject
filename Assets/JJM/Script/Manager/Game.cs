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
        obj.gameObject.layer = (V.playerNumber == obj.caricNumber) ? LayerMask.NameToLayer("Player") : LayerMask.NameToLayer("Enemy");
        obj.sprite.flipX = (obj.gameObject.layer == LayerMask.NameToLayer("Player")) ? false : true;
        
        return obj;
    }
}
