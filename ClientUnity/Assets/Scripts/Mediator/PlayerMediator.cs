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
        m_clsPlayerController1 = r_playerController;

    }

	public void RegistPlayerController2(ThirdPersonCharacter r_playerController)
    {
        m_clsPlayerController2 = r_playerController;
    }
}
