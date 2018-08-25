﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    GameLogic() { }
    static GameLogic m_instance;
    public static GameLogic GetInstance() { return m_instance; }

    // Mediator
    PlayerMediator m_PlayerMediator;
    SceneLoadMediator m_SceneLoadMediator;
    IOMediator m_IOMediator;
    UIMediator m_UIMediator;

    // Proxy
    PlayerProxy m_PlayerProxy;
    TimerProxy m_TimeProxy;
    GameProxy m_GameProxy;

    void Awake()
    {
        Debug.LogWarning("GameLogic / Awake");

        m_instance = this;

        m_PlayerMediator = new PlayerMediator();
        m_SceneLoadMediator = new SceneLoadMediator();
        m_IOMediator = new IOMediator();
        m_UIMediator = new UIMediator();

        m_PlayerProxy = new PlayerProxy();
        m_TimeProxy = new TimerProxy();
        m_GameProxy = new GameProxy();

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Debug.LogWarning("GameLogic / Start");

        m_PlayerMediator.Start();
        m_IOMediator.Start();
        m_UIMediator.Start();

        m_PlayerProxy.Start();
        m_TimeProxy.Start();
        m_GameProxy.Start();

        Init();
    }

    void Init()
    {
        m_PlayerMediator.Init();
        m_IOMediator.Init();
        m_UIMediator.Init();

        m_PlayerProxy.Init();
        m_TimeProxy.Init();
        m_GameProxy.Init();

        SceneLoadMediator.Load(SceneLoadMediator.LOAD_SCENE_TYPE.ToMenu);
    }

    void Update()
    {
        m_IOMediator.Update();
        m_TimeProxy.Update();
    }

    public void StartGame()
    {
        UIMediator.Init();
        TimerProxy.Handle_GameBaseClock();
    }

    #region Proxy & Mediator
    public PlayerMediator PlayerMediator
    {
        get {
           return m_PlayerMediator;
        }
    }

    public SceneLoadMediator SceneLoadMediator
    {
        get {
            return m_SceneLoadMediator;
        }
    }

    public UIMediator UIMediator
    {
        get {
            return m_UIMediator;
        }
    }

    public PlayerProxy PlayerProxy
    {
        get{
            return m_PlayerProxy;
        }
    }

    public TimerProxy TimerProxy
    {
        get{
            return m_TimeProxy;
        }
    }

    public GameProxy GameProxy
    {
        get{
            return m_GameProxy;
        }
    }
    #endregion
}