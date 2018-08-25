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
		for (int i = 0; i < 5; i++) 
		{
			if (HitPoint1 [i].transform.name == HitObj [i]+" (Clone)" && HitObj.Count >0) 
			{
				HitPoint1 [i].SetActive (true);
			}
			if (HitPoint2 [i].transform.name == HitObj [i]+" (Clone)" && HitObj.Count >1) 
			{
				HitPoint2 [i].SetActive (true);
			}
			if (HitPoint3 [i].transform.name == HitObj [i]+" (Clone)" && HitObj.Count >2) 
			{
				HitPoint3 [i].SetActive (true);
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
