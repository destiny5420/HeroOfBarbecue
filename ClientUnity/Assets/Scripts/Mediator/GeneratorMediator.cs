using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMediator 
{
    FoodGenerator m_FoodGenerator;

	public void Start () 
    {
		
	}
	
    public void Init()
    {
        
    }

    public void Update () 
    {
		
	}

    public void Regist_FoodGenerator(FoodGenerator foodGenerator)
    {
        m_FoodGenerator = foodGenerator;
    }

    public void Spawn_Fruit()
    {
        m_FoodGenerator.Init();
    }
}
