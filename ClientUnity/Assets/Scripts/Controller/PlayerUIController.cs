using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour 
{
    [SerializeField] Text m_txtTimer;

    void Awake()
    {
        GameLogic.GetInstance().UIMediator.Regist_PlayerUIController(this);
    }

    void Start ()
    {
		
	}
	
    public void Init()
    {
        m_txtTimer.text = "";
    }

	void Update () 
    {
		
	}
}
