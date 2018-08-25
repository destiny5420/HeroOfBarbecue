using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerMediator
{
	ThirdPersonCharacter m_clsPlayerController1;
	ThirdPersonCharacter m_clsPlayerController2;

    public void Start () 
	{

	}
	
    public void Init()
    {

    }

	void Update () 
    {
		
	}

	public void RegistPlayerController1(ThirdPersonCharacter r_playerController)
    {
        //Debug.Log("RegistPlayerController1");
        m_clsPlayerController1 = r_playerController;
    }

	public void RegistPlayerController2(ThirdPersonCharacter r_playerController)
    {
        //Debug.Log("RegistPlayerController2");
        m_clsPlayerController2 = r_playerController;
    }

	public void Player_1_IO(IO_TYPE ioType)
    {
		//Debug.Log("Player_1_IO / IO: " + ioType.ToString());

        if (GameLogic.GetInstance().PlayerProxy.CheckCanController(1) == false)
            return;

        if (ioType == IO_TYPE.Press_Dash) 
		{
			m_clsPlayerController1.Dash ();
		}
		else if (ioType == IO_TYPE.Press_Attack) 
		{
			m_clsPlayerController1.Attack ();
		}
        else if (ioType == IO_TYPE.Press_Eat)
        {
            m_clsPlayerController1.Eat();
        }
    }

	public void Player_2_IO(IO_TYPE ioType)
    {
		//Debug.Log("Player_2_IO / IO: " + ioType.ToString());

        if (GameLogic.GetInstance().PlayerProxy.CheckCanController(2) == false)
            return;
        
		if (ioType == IO_TYPE.Press_Dash) 
		{
			m_clsPlayerController2.Dash ();
		}
		else if (ioType == IO_TYPE.Press_Attack) 
		{
			m_clsPlayerController2.Attack ();
		}
        else if (ioType == IO_TYPE.Press_Eat)
        {
            m_clsPlayerController2.Eat();
        }
    }

    public void UpdatePlayerFruiltList(int playerID)
    {
        if (playerID == 1)
        {
            m_clsPlayerController1.UpdateFruiltList();
        }
        else if (playerID == 2)
        {
            m_clsPlayerController2.UpdateFruiltList();
        }
    }
}
