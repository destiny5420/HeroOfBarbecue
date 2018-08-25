using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProxy
{
    Dictionary<int, PlayerObj> m_dicPlayerObj;

    public void Start () 
    {
        m_dicPlayerObj = new Dictionary<int, PlayerObj>();
		CreatePlayerData ();
	}
	
    public void Init()
    {

    }

    void CreatePlayerData()
    {
        m_dicPlayerObj.Add(1, new PlayerObj());
        m_dicPlayerObj.Add(2, new PlayerObj());
    }

	void HitObject()
	{
		
	}

	public  void DetectObject(int id)
	{
		
	}

    public void IncreaseFoodList(int playerID, string fruitName)
    {
        if (m_dicPlayerObj[playerID].CheckCanAddFruilt() == false)
        {
            Debug.LogWarning("Spear is full~~~~");
            return;
        }

        m_dicPlayerObj[playerID].AddFruit(fruitName);
        GameLogic.GetInstance().PlayerMediator.UpdatePlayerFruiltList(playerID);

    }

    public void CleanFoodList(int playerID)
    {
        m_dicPlayerObj[playerID].CleanFruit();
        GameLogic.GetInstance().PlayerMediator.UpdatePlayerFruiltList(playerID);
    }

    public void SwitchState_Attack(int playerID, bool key)
    {
        m_dicPlayerObj[playerID].attacking = key;
    }

    public string[] GetPlayFruitListName(int playerID)
    {
        return m_dicPlayerObj[playerID].arrayListName;
    }

    public bool CheckCanController(int playerID)
    {
        if (m_dicPlayerObj[playerID].beAttack)
            return false;

        if (m_dicPlayerObj[playerID].attacking)
            return false;

        return true;
    }
}
