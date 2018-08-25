using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOMediator 
{
    public IOMediator()
    {}

    public void Start()
    {
        
    }

    public void Init()
    {
        
    }

    public void Update()
    {
        // Player1
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IO_Player1(IO_TYPE.Press_Up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            IO_Player1(IO_TYPE.Press_Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            IO_Player1(IO_TYPE.Press_Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            IO_Player1(IO_TYPE.Press_Right);
        }

        // Player2
        if (Input.GetKeyDown(KeyCode.W))
        {
            IO_Player2(IO_TYPE.Press_Up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            IO_Player2(IO_TYPE.Press_Down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            IO_Player2(IO_TYPE.Press_Left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            IO_Player2(IO_TYPE.Press_Right);
        }
    }

    public void IO_Player1(IO_TYPE ioType)
    {
        GameLogic.GetInstance().PlayerMediator.Player_1_IO(ioType);
    }

    public void IO_Player2(IO_TYPE ioType)
    {
        GameLogic.GetInstance().PlayerMediator.Player_2_IO(ioType);
    }
}
