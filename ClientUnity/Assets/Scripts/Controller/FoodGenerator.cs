using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {


    public GameObject Food;

	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < 100;i++){
            GameObject FoodDrop = Instantiate(Food) as GameObject;

            FoodDrop.transform.position = new Vector3(0,i*3,0);

        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
