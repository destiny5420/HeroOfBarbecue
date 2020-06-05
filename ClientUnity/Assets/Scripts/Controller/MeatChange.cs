using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatChange : MonoBehaviour 
{
	public bool isU7;
	public GameObject U7;
	public GameObject Model;

	void Update () 
	{	
		if (Input.GetKeyDown (KeyCode.F10)) 
		{
			if (isU7) 
			{
				U7.SetActive (true);
				Model.SetActive (false);
				isU7 = false;
			}
			else
			{
				U7.SetActive (false);
				Model.SetActive (true);
				isU7 = true;
			}
		}
	}
}
