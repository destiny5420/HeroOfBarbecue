using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMediator 
{
    public PlayerUIController m_PlayerUIController;

	public void Start () 
    {
		
	}

    public void Init()
    {
        if (m_PlayerUIController != null)
            m_PlayerUIController.Init();
    }
	
	public void Update () 
    {
		
	}

    public void Regist_PlayerUIController(PlayerUIController controller)
    {
        Debug.Log("Regist_PlayerUIController");
        m_PlayerUIController = controller;
        m_PlayerUIController.Init();
    }

    public void SetGameBaseTimer(float timer)
    {
        m_PlayerUIController.SetTimer(timer);
    }
<<<<<<< HEAD
=======

    public void Hide_PlayerWinnerPanel()
    {
        
    }

    public void GameOver()
    {
        m_PlayerUIController.GameOver();
    }
>>>>>>> f65abe9e5d07af47e8ae67f60447c27ad5c03a03
}
