using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public enum State
    {
        Up,
        Side,
        Up_left,
        Left_bottom,
        Bottom_right,
        Right_top,
    }

    public State currentState;
    public State correctState;
}
