using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedProxy {

	public string[] Player1WantList = new string[3];
	public string[] Player2WantList = new string[3];
	public string[] Questions = new string[]{"Corn","Fish","GreenPepper","Meat","Mushroom"};


	public void Start () 
    {
        Player1WantList = new string[3];
        Player2WantList = new string[3];
	}

	public void Init()
	{
        CreateNewList(1);
        CreateNewList(2);
    }

    void Update () 
	{
		
	}

    public void CreateNewList(int playerID)
    {
        switch (playerID)
        {
            case 1:
                Player1CreatNewList();
                break;
            case 2:
                Player2CreatNewList();
                break;
        }

        GameLogic.GetInstance().UIMediator.UpdateWantList();
    }

	void Player1CreatNewList()
	{
		for (int i = 0; i < 3; i++) 
		{
			Player1WantList [i] = Questions [Random.Range (0, Questions.Length)];
            Debug.Log ("Player 1 CreatNewList Q["+i+"]: " + Player1WantList [i]);
		}
	}

	void Player2CreatNewList()
	{
		for (int i = 0; i < 3; i++) 
		{
			Player2WantList [i] = Questions [Random.Range (0, Questions.Length)];
            Debug.Log("Player 2 CreatNewList Q[" + i + "]: " + Player2WantList[i]);
		}
	}

    public string[] GetQuestionForPlayer(int plyerID)
    {
        switch (plyerID)
        {
            case 1:
                return Player1WantList;
            case 2:
                return Player2WantList;
            default:
                return null;
        }
    }
}
