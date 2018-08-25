using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj 
{
    int iHp;
    int iStr;
    float fSpeed;
	List<string> HitName;

    public PlayerObj()
    {
        iHp = 100;
        iStr = 10;
        fSpeed = 10;
    }

}