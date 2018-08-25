using System.Collections;
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

    // Proxy
    PlayerProxy m_PlayerProxy;

    void Awake()
    {
        Debug.LogWarning("GameLogic / Awake");

        m_instance = this;

        m_PlayerMediator = new PlayerMediator();

        m_PlayerProxy = new PlayerProxy();

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Debug.LogWarning("GameLogic / Start");

        m_PlayerMediator.Start();
        m_PlayerProxy.Start();

        Init();
    }

    void Init()
    {
        m_PlayerMediator.Init();
        m_PlayerProxy.Init();
    }

    void Update()
    {

    }

    #region Proxy & Mediator
    public PlayerMediator PlayerMediator
    {
        get {
           return m_PlayerMediator;
        }
    }

    public PlayerProxy PlayerProxy
    {
        get
        {
            return m_PlayerProxy;
        }
    }

    #endregion
}