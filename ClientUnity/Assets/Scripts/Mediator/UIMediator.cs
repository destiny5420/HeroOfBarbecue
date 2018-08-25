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
}
