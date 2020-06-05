using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReplayController : ButtonBaseController 
{
    public override void OnClick()
    {
        Debug.Log("OnClick ButtonReplayController");
		SceneManager.LoadScene ("GameBase");
        GameLogic.GetInstance().StartGame();
    }
}
