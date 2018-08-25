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
        m_PlayerUIController = controller;
        m_PlayerUIController.Init();
        m_PlayerUIController.Handle_Ready();
        GameLogic.GetInstance().TimerProxy.Handle_GameBase_SpawnFruit();
    }

    public void SetGameBaseTimer(float timer)
    {
        m_PlayerUIController.SetTimer(timer);
    }

    public void Handle_ReadyPanel()
    {
        m_PlayerUIController.Handle_Ready();
    }

    public void GameOver()
    {
        m_PlayerUIController.GameOver();
    }
}
