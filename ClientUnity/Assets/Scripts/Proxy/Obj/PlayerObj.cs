using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj 
{
    int iHp;
    int iStr;
    float fSpeed;
    string[] sAryFruitList;

    public PlayerObj()
    {
        iHp = 100;
        iStr = 10;
        fSpeed = 10;

        CreateHitNameData();
    }

    void CreateHitNameData()
    {
        sAryFruitList = new string[3];

        for (int i = 0; i < sAryFruitList.Length; i++)
            sAryFruitList[i] = "";
    }

    public void AddFruit(string fruitName)
    {
        for (int i = 0; i < sAryFruitList.Length; i++)
        {
            if (sAryFruitList[i] == "")
            {
                sAryFruitList[i] = fruitName;
                break;
            }
        }
    }

    public string[] arrayListName
    {
        get {
            return sAryFruitList;
        }
    }

    public bool CheckCanAddFruilt()
    {
        for (int i = 0; i < sAryFruitList.Length; i++)
        {
            if (sAryFruitList[i] == "")
                return true;
        }

        return false;
    }
}