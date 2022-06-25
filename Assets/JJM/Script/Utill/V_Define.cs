using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MOVEDIR
{
    STAND = 0,
    LEFT = -1,
    RIGHT = 1,
}

public partial class V : MonoBehaviour
{
    public static readonly KeyCode ATTACK_WEAK_KEY = KeyCode.J;
    public static readonly KeyCode ATTACK_STRONG_KEY = KeyCode.K;
    public static readonly KeyCode DEFENSE_KEY = KeyCode.L;
    public static readonly KeyCode LEFT_MOVE_KEY = KeyCode.A;
    public static readonly KeyCode RIGHT_MOVE_KEY = KeyCode.D;
    public static readonly KeyCode JUMP_KEY = KeyCode.W;
    public static readonly KeyCode CROUCH_KEY = KeyCode.S;

    public static readonly float GROUND_MIN_Y = -4.5f;
    public static readonly float COMMAND_DELAY_TIME = 0.25f;

    public static readonly float PLAYER_MAXHP = 100f;
}
