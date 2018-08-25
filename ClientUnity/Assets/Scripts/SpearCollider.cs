using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollider : MonoBehaviour {

	public List<string> HitObj;
	public GameObject[] HitPoint1;
	public GameObject[] HitPoint2;
	public GameObject[] HitPoint3;

	void Update()
	{
		for (int i = 0; i < 4; i++) 
		{
			if (HitObj.Count > 2) 
			{

				if (HitPoint1 [i].transform.name == HitObj [0]+"(Clone)") 
				{
					HitPoint1 [i].SetActive (true);
				}
				if (HitPoint2 [i].transform.name == HitObj [1]+"(Clone)") 
				{
					HitPoint2 [i].SetActive (true);
				}
				if (HitPoint3 [i].transform.name == HitObj [2]+"(Clone)") 
				{
					HitPoint3 [i].SetActive (true);
				}
			}
			else if (HitObj.Count == 2) 
			{

				if (HitPoint1 [i].transform.name == HitObj [0]+"(Clone)") 
				{
					HitPoint1 [i].SetActive (true);
				}
				if (HitPoint2 [i].transform.name == HitObj [1]+"(Clone)") 
				{
					HitPoint2 [i].SetActive (true);
				}
			}
			else if (HitObj.Count == 1) 
			{
				if (HitPoint1 [i].transform.name == HitObj [0]+"(Clone)") 
				{
					HitPoint1 [i].SetActive (true);
				}
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Food") 
		{
			HitObj.Add (collision.transform.name);
		}
	}
}
