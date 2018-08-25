using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollider : MonoBehaviour {

	public List<string> HitObj;
	public GameObject[] HitPoint1;
	public GameObject[] HitPoint2;
	public GameObject[] HitPoint3;

    [SerializeField] BoxCollider m_colBox;
    bool bIsHitTarget;

    public void Init()
    {
        SwitchCollider(false);
        bIsHitTarget = false;
    }

	void Update()
	{
		for (int i = 0; i < 4; i++) 
		{
			if (HitObj.Count > 2) 
			{

				if (HitPoint1 [i].transform.name+"(Clone)" == HitObj [0]) 
				{
					HitPoint1 [i].SetActive (true);
				}
				if (HitPoint2 [i].transform.name+"(Clone)" == HitObj [1]) 
				{
					HitPoint2 [i].SetActive (true);
				}
				if (HitPoint3 [i].transform.name+"(Clone)" == HitObj [2]) 
				{
					HitPoint3 [i].SetActive (true);
				}
			}
			else if (HitObj.Count == 2) 
			{

				if (HitPoint1 [i].transform.name+"(Clone)" == HitObj [0]) 
				{
					HitPoint1 [i].SetActive (true);
				}
				if (HitPoint2 [i].transform.name+"(Clone)" == HitObj [1]) 
				{
					HitPoint2 [i].SetActive (true);
				}
			}
			else if (HitObj.Count == 1) 
			{
				if (HitPoint1 [i].transform.name+"(Clone)" == HitObj [0]) 
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
		Debug.Log (collision.transform.name);
	}

    void OnTriggerEnter(Collider other)
    {
        if (bIsHitTarget)
            return;

        if (other.transform.tag == "Food")
        {
            bIsHitTarget = true;
            FruitController obj = other.transform.parent.GetComponent<FruitController>();

            Debug.Log("OnTriggerEnter / other name: " + obj.Name);
        }
    }

    public void SwitchCollider(bool key)
    {
        m_colBox.enabled = key;

        if (key == false)
            bIsHitTarget = false;
    }
}
