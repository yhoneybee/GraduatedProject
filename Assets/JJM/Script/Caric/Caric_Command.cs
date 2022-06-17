using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caric_Command : MonoBehaviour
{
    public Caric caric;

    public float resetTimer;
    private float commandTime = 0.25f;

    private Queue<string> commadQueue = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        caric = GetComponent<Caric>();
        resetTimer = V.worldTime + commandTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (V.GetKeyDown(V.LEFT_MOVE_KEY)) 
        {
            AddCommand("��");
        }
        else if (V.GetKeyDown(V.RIGHT_MOVE_KEY))
        {
            AddCommand("��");
        }
        else if (V.GetKeyDown(V.CROUCH_KEY))
        {
            AddCommand("��");
        }
        else if (V.GetKeyDown(V.JUMP_KEY))
        {
            AddCommand("��");
        }
        
    }

    private void FixedUpdate()
    {
        if (resetTimer <= V.worldTime)
        {
            commadQueue.Clear();
            resetTimer = V.worldTime + commandTime;
        }
    }
    //"��"
    private void AddCommand(string command) 
    {
        commadQueue.Enqueue(command);
        resetTimer = V.worldTime + commandTime;
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
            case "J���":
            case "J���":
                break;
            case "K���":
            case "K���":
                break;
            default:

                switch (attackname) 
                {
                    case "J":
                        caric.SetAttackState(gameObject.AddComponent<Attack_Weak>());
                        break;
                    case "K":
                        caric.SetAttackState(gameObject.AddComponent<Attack_Strong>());
                        break;
                    case "J��":
                        caric.SetAttackState(gameObject.AddComponent<Attack_Crouch>());
                        break;
                    case "J��":
                        caric.SetAttackState(gameObject.AddComponent<Attack_Jump>());
                        break;

                }

                break;
        }
    }
}
