using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneratorNew : MonoBehaviour 
{
	public Transform FruitMother;
	public List<GameObject> FruitCreated;
	public GameObject[] FruitKind;
	public Vector3[] FruitPos;
	public int MaxCount;


	void Start () 
	{
		CreatFruits ();
	}

	void Update () 
	{
		
	}

	public void CreatFruits()
	{
		if (FruitCreated.Count < MaxCount) 
		{
			for (int i = 0; i < Random.Range (2, 5); i++) 
			{
				GameObject Fruits = Instantiate (FruitKind [Random.Range (0, FruitKind.Length)], new Vector3 (Random.Range (0, 10), 20, Random.Range (0, 10)), transform.rotation, FruitMother);
				FruitCreated.Add (Fruits);
			}
		}
	}
}
