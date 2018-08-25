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
}
