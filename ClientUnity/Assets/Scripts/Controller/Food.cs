using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{

    float killRate = 16.0f;
    float nextKill = 16.0f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        if(Time.time > nextKill){
            nextKill = Time.time + killRate;

            GameLogic.GetInstance().GeneratorMediator.Auto_Kill_Fruit(gameObject);
        }

	}
}
