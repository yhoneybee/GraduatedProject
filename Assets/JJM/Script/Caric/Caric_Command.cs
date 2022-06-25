using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caric_Command : MonoBehaviour
{
    public Caric caric;

    public float resetTimer;

    private Queue<string> commadQueue = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        caric = GetComponent<Caric>();
        resetTimer = V.worldTime + V.COMMAND_DELAY_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        if (V.GetKeyDown(V.LEFT_MOVE_KEY)) 
        {
            AddCommand("¡ç");
        }
        else if (V.GetKeyDown(V.RIGHT_MOVE_KEY))
        {
            AddCommand("¡æ");
        }
        else if (V.GetKeyDown(V.CROUCH_KEY))
        {
            AddCommand("¡é");
        }
        else if (V.GetKeyDown(V.JUMP_KEY))
        {
            AddCommand("¡è");
        }
        
    }

    private void FixedUpdate()
    {
        if (resetTimer <= V.worldTime)
        {
            commadQueue.Clear();
            resetTimer = V.worldTime + V.COMMAND_DELAY_TIME;
        }
    }
    //"¡ç"
    private void AddCommand(string command) 
    {
        commadQueue.Enqueue(command);
        resetTimer = V.worldTime + V.COMMAND_DELAY_TIME;
    }

    public void CheckCommad(string attackname)
    {
        string skillname = attackname;
        for (; commadQueue.Count > 0;)
        {
            skillname += commadQueue.Dequeue();
        }

        switch (skillname)
        {
            case "J¡é¡æ":
            case "J¡é¡ç":
                caric.SetCommandState(ATTACK_STATE.ATTACK_COMMAND_WEAK);
                break;
            case "K¡é¡æ":
            case "K¡é¡ç":
                caric.SetCommandState(ATTACK_STATE.ATTACK_COMMAND_STRONG);
                break;
            default:

                switch (attackname) 
                {
                    case "J":
                        caric.SetCommandState(ATTACK_STATE.ATTACK_WEAK);
                        break;
                    case "K":
                        caric.SetCommandState(ATTACK_STATE.ATTACK_STRONG);
                        break;
                    case "J¡é":
                        caric.SetCommandState(ATTACK_STATE.ATTACK_CROUCH);
                        break;
                    case "J¡è":
                        caric.SetCommandState(ATTACK_STATE.ATTACK_JUMP);
                        break;
                }

                break;
        }

    }
}
