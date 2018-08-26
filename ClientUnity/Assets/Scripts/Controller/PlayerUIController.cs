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

    [SerializeField] Image m_imgWinner;
    [SerializeField] Image[] m_imgPlayer1_Wants;
    [SerializeField] Image[] m_imgPlayer2_Wants;

    [SerializeField] Sprite m_spritePlayer1;
    [SerializeField] Sprite m_spritePlayer2;
    [SerializeField] Sprite m_spritePlayerFlat;
    [SerializeField] Sprite m_spriteCorn;
    [SerializeField] Sprite m_spriteFish;
    [SerializeField] Sprite m_spriteGreenPepper;
    [SerializeField] Sprite m_spriteMeat;
    [SerializeField] Sprite m_spriteMushroom;

    [SerializeField] Image[] m_imgAryItem1;
    [SerializeField] Image[] m_imgAryItem2;

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

	public AudioClip FinishSound;

    void Awake()
    {
        GameLogic.GetInstance().UIMediator.Regist_PlayerUIController(this);
    }

    void Start()
    {
        UpdateWantList();
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

        m_imgWinner.sprite = null;

        UpdateScore();
        UpdateWantList();
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

        CalResult();
		GetComponent<AudioSource> ().PlayOneShot (FinishSound);
    }

    void CalResult()
    {
        long lScorePlayer1 = GameLogic.GetInstance().PlayerProxy.GetScore(1);
        long lScorePlayer2 = GameLogic.GetInstance().PlayerProxy.GetScore(2);

        int iWinNumOfPlayer;

        if (lScorePlayer1 > lScorePlayer2)
            iWinNumOfPlayer = 1;
        else if (lScorePlayer1 < lScorePlayer2)
            iWinNumOfPlayer = 2;
        else
            iWinNumOfPlayer = 0;

        if (iWinNumOfPlayer == 1)
            m_imgWinner.sprite = m_spritePlayer1;
        else if (iWinNumOfPlayer == 2)
            m_imgWinner.sprite = m_spritePlayer2;
        else if (iWinNumOfPlayer == 0)
            m_imgWinner.sprite = m_spritePlayerFlat;
    }

    void SettingMessage(string message)
    {
        m_txtMessage.text = message;
    }

    public void UpdateScore()
    {
        long lScorePlayer1 = GameLogic.GetInstance().PlayerProxy.GetScore(1);
        long lScorePlayer2 = GameLogic.GetInstance().PlayerProxy.GetScore(2);

        //m_txtPlayer1_Score.text = lScorePlayer1.ToString();
        //m_txtPlayer2_Score.text = lScorePlayer2.ToString();

        for (int i = 0; i < m_imgAryItem1.Length; i++)
        {
            if (lScorePlayer1 != 0)
            {
                m_imgAryItem1[i].enabled = true;
                lScorePlayer1--;
            }
            else
                m_imgAryItem1[i].enabled = false;
        }

        for (int i = 0; i < m_imgAryItem2.Length; i++)
        {
            if (lScorePlayer2 != 0)
            {
                m_imgAryItem2[i].enabled = true;
                lScorePlayer2--;
            }
            else
                m_imgAryItem2[i].enabled = false;
        }
    }

    public void UpdateWantList()
    {
        string[] sAryWantList_1 = GameLogic.GetInstance().WantedProxy.GetQuestionForPlayer(1);
        string[] sAryWantList_2 = GameLogic.GetInstance().WantedProxy.GetQuestionForPlayer(2);

        for (int i = 0; i < sAryWantList_1.Length; i++)
            m_imgPlayer1_Wants[i].sprite = GetSprite(sAryWantList_1[i]);
        
        for (int i = 0; i < sAryWantList_2.Length; i++)
            m_imgPlayer2_Wants[i].sprite = GetSprite(sAryWantList_2[i]);
    }

    Sprite GetSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Corn":
                return m_spriteCorn;
            case "Fish":
                return m_spriteFish;
            case "GreenPepper":
                return m_spriteGreenPepper;
            case "Meat":
                return m_spriteMeat;
            case "Mushroom":
                return m_spriteMushroom;
            default:
                return null;
        }
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
            GameLogic.GetInstance().GameProxy.gamePause = false;
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
