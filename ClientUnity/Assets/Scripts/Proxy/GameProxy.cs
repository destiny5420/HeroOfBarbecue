using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProxy 
{
    bool m_bGamePause;
    	
    public void Start()
    {}

    public void Init()
    {
        m_bGamePause = false;
    }

    public bool gamePause
    {
        get {
            return m_bGamePause;
        }
        set {
            m_bGamePause = value;
        }
    }
}
