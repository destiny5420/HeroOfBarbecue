using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour 
{
    [SerializeField] Text m_txtTimer;
    [SerializeField] RectTransform m_rectTranWinnerPanel;
    [SerializeField] Transform m_tranShiny;
    Vector3 m_v3WinnerPanelHidePos = new Vector3(0.0f, 2000.0f, 0.0f);
    Vector3 m_v3WinnerPanelShowPos = new Vector3(0.0f, 0.0f, 0.0f);

    // Timer
    bool bRotShiny;
    const float m_fRoyShinyUnit = 100.0f;

    void Awake()
    {
        GameLogic.GetInstance().UIMediator.Regist_PlayerUIController(this);
    }

    void Start ()
    {
        
	}

    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (bRotShiny)
        {
            m_tranShiny.eulerAngles += new Vector3(0.0f, 0.0f, m_fRoyShinyUnit * Time.deltaTime * (-1.0f));
        }
    }

    public void Init()
    {
        Debug.Log("PlayerUIController Init");
        bRotShiny = false;
        m_tranShiny.eulerAngles = Vector3.zero;
        m_txtTimer.text = "";
        m_rectTranWinnerPanel.transform.position = m_v3WinnerPanelHidePos;
    }

    public void SetTimer(float timer)
    {
        m_txtTimer.text = timer.ToString();
    }

    public void GameOver()
    {
        bRotShiny = true;
        m_rectTranWinnerPanel.transform.position = m_v3WinnerPanelShowPos;
    }
}
