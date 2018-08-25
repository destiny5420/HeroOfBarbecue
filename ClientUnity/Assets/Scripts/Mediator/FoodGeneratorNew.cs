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
		GameLogic.GetInstance ().GeneratorMediator.Regist_FoodGenerator (GetComponent<FoodGeneratorNew> ());
	}

	void Update () 
	{
		
	}

	public void Init()
	{
		
	}

	public void CreatFruits()
	{
		if (FruitCreated.Count < MaxCount) 
		{
			for (int i = 0; i < Random.Range (2, 5); i++) 
			{
				GameObject Fruits = Instantiate (FruitKind [Random.Range (0, FruitKind.Length)], new Vector3 (Random.Range (-10, 10), 20, Random.Range (-10, 10)), transform.rotation, FruitMother);
				FruitCreated.Add (Fruits);
			}
		}
	}

	public void KillFruit(GameObject Fruit)
	{
		FruitCreated.Remove (Fruit);
		Destroy (Fruit);
	}
}
