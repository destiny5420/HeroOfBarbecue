using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerProxy
{
    const float m_fDefaultGameBaseTime = 5.0f;
    const float m_fGameBaseTimeOfOver = 1.0f;
    bool m_bStart_GameBaseClock;
    float m_fGameBaseClock;

    public void Start()
    {

    }

    public void Init()
    {
        m_bStart_GameBaseClock = false;
        m_fGameBaseClock = m_fDefaultGameBaseTime;
    }

    public void Update()
    {
        if (m_bStart_GameBaseClock)
            GameBaseClock();
    }

    void GameBaseClock()
    {
        m_fGameBaseClock -= Time.deltaTime;

        if (CheckTimeOut() == false)
            GameLogic.GetInstance().UIMediator.SetGameBaseTimer((int)m_fGameBaseClock);
    }

    bool CheckTimeOut()
    {
        if (m_fGameBaseClock <= m_fGameBaseTimeOfOver)
        {
            m_fGameBaseClock = 0.0f;
            m_bStart_GameBaseClock = false;
            GameLogic.GetInstance().UIMediator.SetGameBaseTimer((int)m_fGameBaseClock);
            Debug.LogWarning("Time is over!!");
            return true;
        }

        return false;
    }

    #region Hanedle
    public void Handle_GameBaseClock()
    {
        m_fGameBaseClock = m_fDefaultGameBaseTime;
        m_bStart_GameBaseClock = true;
    }
    #endregion
}
