using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMediator 
{
    PlayerController m_clsPlayerController1;
    PlayerController m_clsPlayerController2;

    public void Start () 
    {
		
	}
	
    public void Init()
    {

    }

	void Update () 
    {
		
	}

    public void RegistPlayerController1(PlayerController r_playerController)
    {
        m_clsPlayerController1 = r_playerController;
    }

    public void RegistPlayerController2(PlayerController r_playerController)
    {
        m_clsPlayerController2 = r_playerController;
    }
}
