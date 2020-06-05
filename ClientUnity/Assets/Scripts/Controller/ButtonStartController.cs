using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartController : ButtonBaseController 
{
    public override void OnClick()
    {
        GameLogic.GetInstance().SceneLoadMediator.Load(SceneLoadMediator.LOAD_SCENE_TYPE.ToGameBase);
    }
}
