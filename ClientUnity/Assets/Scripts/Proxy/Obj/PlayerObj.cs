using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj 
{
    float fSpeed;
    string[] sAryFruitList;

    // State
    bool bBeAttack;
    bool bAttacking;
	bool CanDash;

    public PlayerObj()
    {
        sAryFruitList = new string[3];

        Init();
    }

    public void Init()
    {
        bBeAttack = false;
        bAttacking = false;

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
				Debug.Log ("Add:"+sAryFruitList [i]);
                break;
            }
        }
    }

	public void DropFruit(int playerID)
	{
		Debug.Log (sAryFruitList.Length);
		for (int i = 2; i >= 0; i--)
		{
			if (sAryFruitList [i] != "") 
			{
				GameLogic.GetInstance ().PlayerMediator.DropFruit (playerID,sAryFruitList [i]);
				sAryFruitList [i] = "";
				break;
			}
		}
	}

    public void CleanFruit()
    {
        for (int i = 0; i < sAryFruitList.Length; i++)
            sAryFruitList[i] = "";
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

	public bool canDash
	{
		get{ 
			return CanDash;
		}
	}

    public bool fruitListIsFull
    {
        get {
            
            for (int i = 0; i < sAryFruitList.Length; i++)
            {
                if (sAryFruitList[i] == "")
                    return false;
            }

            return true;
        }
    }
}