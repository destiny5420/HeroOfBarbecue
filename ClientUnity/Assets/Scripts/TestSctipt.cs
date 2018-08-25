using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSctipt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			GameLogic.GetInstance ().WantedProxy.Player1CreatNewList ();
		}
	}
}
