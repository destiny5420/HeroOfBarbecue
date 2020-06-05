using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerProxy
{
    const float m_fDefaultGameBaseTime = 180.0f;
    const float m_fGameBaseTimeOfOver = 1.0f;
    bool m_bStart_GameBaseClock;
    float m_fGameBaseClock;

    bool bSpawnFruit;
    const float m_fDefaultSpawnFruitClock = 0.0f;
    const float m_fSpawnFruitTime = 5.0f;
    float m_fSpawnFruitClock;

    public void Start()
    {

    }

    public void Init()
    {
        m_bStart_GameBaseClock = false;
        m_fGameBaseClock = m_fDefaultGameBaseTime;
        m_fSpawnFruitClock = m_fDefaultSpawnFruitClock;
        bSpawnFruit = false;
    }

    public void Update()
    {
        if (m_bStart_GameBaseClock)
            GameBaseClock();

        if (bSpawnFruit)
        {
            m_fSpawnFruitClock += Time.deltaTime;
            if (m_fSpawnFruitClock >= m_fSpawnFruitTime)
                OnSpawnFruitComplete();
        }
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

            GameLogic.GetInstance().GameOver();

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

    public void Handle_GameBase_SpawnFruit()
    {
        m_fSpawnFruitClock = m_fDefaultSpawnFruitClock;
        bSpawnFruit = true;
    }
    #endregion

    #region Complete
    void OnSpawnFruitComplete()
    {
        m_fSpawnFruitClock = 0.0f;
		GameLogic.GetInstance().GeneratorMediator.Creat_Fruit();
    }
    #endregion
}
