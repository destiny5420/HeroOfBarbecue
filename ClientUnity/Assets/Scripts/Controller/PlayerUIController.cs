using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour 
{
    [SerializeField] Text m_txtTimer;
    [SerializeField] RectTransform m_rectTranWinnerPanel;

    Vector3 m_v3WinnerPanelHidePos = new Vector3(0.0f, 2000.0f, 0.0f);
    Vector3 m_v3WinnerPanelShowPos = new Vector3(0.0f, 0.0f, 0.0f);

    void Awake()
    {
        GameLogic.GetInstance().UIMediator.Regist_PlayerUIController(this);
    }

    void Start ()
    {
        
	}

    private void Update()
    {

    }

    public void Init()
    {
        m_txtTimer.text = "";
        m_rectTranWinnerPanel.transform.position = m_v3WinnerPanelHidePos;
    }

    public void SetTimer(float timer)
    {
        m_txtTimer.text = timer.ToString();
    }
}
