using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour 
{
    [SerializeField] string m_sName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string Name
    {
        get{
            return m_sName;
        }
    }
}
