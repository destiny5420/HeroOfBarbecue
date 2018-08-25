using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj 
{
    int iHp;
    int iStr;
    float fSpeed;
    string[] sAryFruitList;

    // State
    bool bBeAttack;
    bool bAttacking;

    public PlayerObj()
    {
        iHp = 100;
        iStr = 10;
        fSpeed = 10;
        bBeAttack = false;
        bAttacking = false;
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

    public bool attacking
    {
        get{
            return bAttacking;
        }
        set{
            bAttacking = value;
        }
    }

    public bool beAttack
    {
        get {
            return bBeAttack;
        }
    }
}