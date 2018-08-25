using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedProxy {

	public string[] Player1WantList = new string[3];
	public string[] Player2WantList = new string[3];
	public string[] Questions = new string[]{"Corn","Fish","GreenPepper","Meat","Mushroom"};


	public void Start () 
	{
		Player1CreatNewList ();
		Player2CreatNewList ();
	}


	public void Init()
	{

	}

	void Update () 
	{
		Player1WantList = new string[3];
		Player2WantList = new string[3];
	}

	public void Player1CreatNewList()
	{
		for (int i = 0; i < 3; i++) 
		{
			Player1WantList [i] = Questions [Random.Range (0, Questions.Length)];
			Debug.Log (Player1WantList [i] );
		}
	}

	public void Player2CreatNewList()
	{
		for (int i = 0; i < 3; i++) 
		{
			Player2WantList [i] = Questions [Random.Range (0, Questions.Length)];
			Debug.Log (Player2WantList [i] );
		}
	}
}
