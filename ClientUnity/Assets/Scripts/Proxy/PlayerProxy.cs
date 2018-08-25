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

    public string[] GetPlayFruitListName(int playerID)
    {
        return m_dicPlayerObj[playerID].arrayListName;
    }
}
