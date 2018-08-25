using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadMediator
{
    public enum LOAD_SCENE_TYPE
    {
        ToMenu = 0,
        ToGameBase,
    }

    public void Start()
    { }

    public void Init()
    {
        
    }

    public void Update()
    {
        
    }

    public void Load(LOAD_SCENE_TYPE r_sceneType)
    {
        switch (r_sceneType)
        {
            case LOAD_SCENE_TYPE.ToMenu:
                {
                    SceneManager.LoadScene("GameMenu");
                }
                break;
            case LOAD_SCENE_TYPE.ToGameBase:
                {
                    SceneManager.LoadScene("GameBase");
<<<<<<< HEAD
                    GameLogic.GetInstance().TimerProxy.Handle_GameBaseClock();
=======
                    GameLogic.GetInstance().StartGame();
>>>>>>> f65abe9e5d07af47e8ae67f60447c27ad5c03a03
                }
                break;
        }
    }
}
