using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMediator 
{
    FoodGeneratorNew m_FoodGenerator;

	public void Start () 
    {
		
	}
	
    public void Init()
    {
        
    }

    public void Update () 
    {
		
	}

    public void Regist_FoodGenerator(FoodGeneratorNew foodGenerator)
    {
        //Debug.Log("Regist_FoodGenerator");
        m_FoodGenerator = foodGenerator;
    }

	public void Creat_Fruit ()
	{
		m_FoodGenerator.CreatFruits ();
	}

	public void Kill_Fruit (GameObject Fruit)
    {
		m_FoodGenerator.KillFruit (Fruit);
    }

    public void Auto_Kill_Fruit(GameObject Fruit)
    {
        m_FoodGenerator.AutoKillFruit(Fruit);
    }
}