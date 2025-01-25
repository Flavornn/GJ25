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

    public enum PipeType
    {
        Straight,
        Corner,
        Three,
        Four
    }

    public State currentState;
    public State correctState;

    public PipeType pipeType;

    private void OnMouseDown()
    {
        if(pipeType == PipeType.Straight)
        {
            transform.Rotate(0, 0, 90);
            if(currentState == State.Up)
            {
                currentState = State.Side;
            }
            else
            {
                currentState = State.Up;
            }
        }
        if (pipeType == PipeType.Corner)
        {
            transform.Rotate(90, 0, 0);

            if ((int)currentState == 5)
            {
                currentState = State.Up_left;
            }
            else
            {
                currentState = currentState + 1;
            }
            
        }
    }
}
