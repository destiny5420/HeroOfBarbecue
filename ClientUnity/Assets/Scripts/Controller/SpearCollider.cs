using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollider : MonoBehaviour {

    [SerializeField] ThirdPersonCharacter m_ThirdPersonCharacter;
	public List<string> HitObj;
	public GameObject[] HitPoint1;
	public GameObject[] HitPoint2;
	public GameObject[] HitPoint3;


    [SerializeField] MeshFilter[] mesFilterFruits;
    [SerializeField] MeshRenderer[] meshRenderers;

    [SerializeField] Mesh mesCorn;
    [SerializeField] Mesh meshFish;
    [SerializeField] Mesh mesGreenPepper;
    [SerializeField] Mesh mesMeat;
    [SerializeField] Mesh mesMushroom;

    [SerializeField] Material matCorn;
    [SerializeField] Material matFish;
    [SerializeField] Material matGreenPepper;
    [SerializeField] Material matMeat;
    [SerializeField] Material matMushroom;

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

            GameLogic.GetInstance().PlayerProxy.IncreaseFoodList(m_ThirdPersonCharacter.PlayerID + 1, obj.Name);

            Debug.Log("OnTriggerEnter / other name: " + obj.Name);
        }
    }

    public void SwitchCollider(bool key)
    {
        m_colBox.enabled = key;

        if (key == false)
            bIsHitTarget = false;
    }

    public void DisplayFruilt(string[] fruitName)
    {
        Debug.LogWarning("SpearCollider / DisplayFruilt / fruitName length: " + fruitName.Length + " / mesFilterFruits length: " + mesFilterFruits.Length);

        for (int i = 0; i < fruitName.Length; i++)
        {
            Debug.Log("["+i+"] fruitName : " + fruitName[i]);
        }

        for (int i = 0; i < fruitName.Length; i++)
        {
            if (fruitName[i] == "")
            {
                mesFilterFruits[i].gameObject.SetActive(false);
                continue;
            }

            Mesh tmpMesh = GetMesh(fruitName[i]);
            Material tmpMat = GetMaterial(fruitName[i]);

            meshRenderers[i].material = tmpMat;
            mesFilterFruits[i].mesh = tmpMesh;
            mesFilterFruits[i].gameObject.SetActive(true);
        }
    }

    Mesh GetMesh(string fruitName)
    {
        switch (fruitName)
        {
            case "Corn":
                return mesCorn;
            case "Fish":
                return meshFish;
            case "GreenPepper":
                return mesGreenPepper;
            case "Meat":
                return mesMeat;
            case "Mushroom":
                return mesMushroom;
            default:
                return null;
        }
    }

    Material GetMaterial(string fruitName)
    {
        switch (fruitName)
        {
            case "Corn":
                return matCorn;
            case "Fish":
                return matFish;
            case "GreenPepper":
                return matGreenPepper;
            case "Meat":
                return matMeat;
            case "Mushroom":
                return matMushroom;
            default:
                return null;
        }
    }
}
