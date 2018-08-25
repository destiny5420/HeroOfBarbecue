using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerProxy
{
    const float m_fDefaultGameBaseTime = 300.0f;
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
        GameLogic.GetInstance().UIMediator.SetGameBaseTimer((int)m_fGameBaseClock);
    }

    #region Hanedle
    public void Handle_GameBaseClock()
    {
        m_fGameBaseClock = m_fDefaultGameBaseTime;
        m_bStart_GameBaseClock = true;
    }
    #endregion
}
