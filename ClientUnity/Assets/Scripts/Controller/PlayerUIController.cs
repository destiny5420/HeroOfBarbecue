using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] Text m_txtTimer;
    [SerializeField] Text m_txtMessage;
    [SerializeField] Text m_txtPlayer1_Score;
    [SerializeField] Text m_txtPlayer2_Score;
    [SerializeField] RectTransform m_rectTranWinnerPanel;
    [SerializeField] RectTransform m_rectTranReadyPanel;
    [SerializeField] Transform m_tranShiny;
    [SerializeField] Transform m_tranMessage;

    Vector3 m_v3WinnerPanelHidePos = new Vector3(0.0f, 2000.0f, 0.0f);
    Vector3 m_v3WinnerPanelShowPos = new Vector3(0.0f, 0.0f, 0.0f);

    Vector3 m_v3ReadyPanelHidePos = new Vector3(0.0f, 3000.0f, 0.0f);
    Vector3 m_v3ReadyPanelShowPos = new Vector3(0.0f, 0.0f, 0.0f);

    Vector3 m_v3StartScale = new Vector3(3.0f, 3.0f, 3.0f);
    Vector3 m_v3EndScale = new Vector3(1.0f, 1.0f, 1.0f);

    // Timer
    bool bRotShiny;
    const float m_fRoyShinyUnit = 100.0f;

    bool bScale;
    const float m_fDefaultScaleValue = 0.0f;
    const float m_fScaleTime = 0.3f;
    float m_fScaleValue;

    bool bDelayGo;
    const float m_fDefaultDelayGoClock = 0.0f;
    const float m_fDelayGoTime = 1.0f;
    float m_fDelayGoClock;

    bool m_bStartGame;

    bool m_bDelayHideGo;
    const float m_fDefaultDelayGoTime = 0.0f;
    const float m_fDelayHideGoTime = 1.0f;
    float m_fDelayHideGoTimeClock;

    void Awake()
    {
        GameLogic.GetInstance().UIMediator.Regist_PlayerUIController(this);
    }

    void Start()
    {

    }

    void Update()
    {
        if (bScale)
        {
            m_fScaleValue += Time.deltaTime / m_fScaleTime;
            m_tranMessage.localScale = Vector3.Lerp(m_v3StartScale, m_v3EndScale, m_fScaleValue);

            if (m_fScaleValue >= 1.0f)
                OnScaleValueComplete();
        }

        if (bDelayGo)
        {
            m_fDelayGoClock += Time.deltaTime;
            if (m_fDelayGoClock >= m_fDelayGoTime)
                OnDelayGoComplete();
        }

        if (m_bDelayHideGo)
        {
            m_fDelayHideGoTimeClock += Time.deltaTime;

            if (m_fDelayHideGoTimeClock >= m_fDelayHideGoTime)
                OnDelayHideGoTimeComplete();
        }
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
        bRotShiny = false;
        m_tranShiny.eulerAngles = Vector3.zero;
        m_txtMessage.text = "";
        m_txtTimer.text = "";
        m_rectTranWinnerPanel.transform.position = m_v3WinnerPanelHidePos;
        m_rectTranReadyPanel.transform.position = m_v3ReadyPanelHidePos;

        bScale = false;
        m_fScaleValue = m_fDefaultScaleValue;

        bDelayGo = false;
        m_fDelayGoClock = m_fDefaultDelayGoClock;

        m_bStartGame = false;

        m_bDelayHideGo = false;
        m_fDelayHideGoTimeClock = m_fDefaultDelayGoTime;

        UpdateScore();
    }

    public void SetTimer(float timer)
    {
        m_txtTimer.text = timer.ToString();
    }

    public void Handle_Ready()
    {
        SettingMessage("READY");
        bScale = true;
        m_fScaleValue = m_fDefaultScaleValue;
        m_tranMessage.localScale = Vector3.Lerp(m_v3StartScale, m_v3EndScale, m_fScaleValue);
        m_rectTranReadyPanel.transform.position = m_v3ReadyPanelShowPos;
    }

    public void Handle_Go()
    {
        SettingMessage("GO");
        bScale = true;
        m_fScaleValue = m_fDefaultScaleValue;
        m_tranMessage.localScale = Vector3.Lerp(m_v3StartScale, m_v3EndScale, m_fScaleValue);
    }

    void Handle_DelayGo()
    {
        m_bStartGame = true;
        bDelayGo = true;
        m_fDelayGoClock = m_fDefaultDelayGoClock;
    }

    public void GameOver()
    {
        bRotShiny = true;
        m_rectTranWinnerPanel.transform.position = m_v3WinnerPanelShowPos;
    }

    void SettingMessage(string message)
    {
        m_txtMessage.text = message;
    }

    public void UpdateScore()
    {
        long lScorePlayer1 = GameLogic.GetInstance().PlayerProxy.GetScore(1);
        long lScorePlayer2 = GameLogic.GetInstance().PlayerProxy.GetScore(2);

        Debug.Log("lScorePlayer1: " + lScorePlayer1);
        Debug.Log("lScorePlayer2: " + lScorePlayer2);

        m_txtPlayer1_Score.text = lScorePlayer1.ToString();
        m_txtPlayer2_Score.text = lScorePlayer2.ToString();
    }

    #region Complete
    void OnScaleValueComplete()
    {
        bScale = false;

        m_fScaleValue = 1.0f;
        m_tranMessage.localScale = Vector3.Lerp(m_v3StartScale, m_v3EndScale, m_fScaleValue);

        if (m_bStartGame)
        {
            m_bDelayHideGo = true;
        }
        else
            Handle_DelayGo();
    }

    void OnDelayGoComplete()
    {
        bDelayGo = false;

        Handle_Go();
    }

    void OnDelayHideGoTimeComplete()
    {
        m_bDelayHideGo = false;
        GameLogic.GetInstance().TimerProxy.Handle_GameBaseClock();
        SettingMessage("");
        m_rectTranReadyPanel.transform.position = m_v3ReadyPanelHidePos;
    }
    #endregion
}
