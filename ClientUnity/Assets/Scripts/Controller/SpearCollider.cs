using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollider : MonoBehaviour {

    [SerializeField] ThirdPersonCharacter m_ThirdPersonCharacter;
	public List<string> HitObj;

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
	public AudioClip HitSound;

    public void Init()
    {
        SwitchCollider(false);
        bIsHitTarget = false;
    }

	void Update()
	{
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

			GameLogic.GetInstance().PlayerProxy.IncreaseFoodList(m_ThirdPersonCharacter.PlayerID, obj.Name);
			GetComponent<AudioSource> ().PlayOneShot (HitSound);

			GameLogic.GetInstance ().GeneratorMediator.Kill_Fruit (other.transform.parent.gameObject);
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
        //Debug.LogWarning("SpearCollider / DisplayFruilt / fruitName length: " + fruitName.Length + " / mesFilterFruits length: " + mesFilterFruits.Length);

        //for (int i = 0; i < fruitName.Length; i++)
        //{
        //    Debug.Log("["+i+"] fruitName : " + fruitName[i]);
        //}

        for (int i = 0; i < fruitName.Length; i++)
        {
            if (fruitName[i] == "")
            {
                mesFilterFruits[i].gameObject.SetActive(false);
                continue;
            }

            Mesh tmpMesh = GetMesh(fruitName[i]);
            Material tmpMat = GetMaterial(fruitName[i]);
			Vector3 tmpRot = GetRotate (fruitName [i]);
			float tmpScale = GetScale (fruitName [i]);

            meshRenderers[i].material = tmpMat;
            mesFilterFruits[i].mesh = tmpMesh;
            mesFilterFruits[i].gameObject.SetActive(true);
			mesFilterFruits [i].transform.localEulerAngles = tmpRot;
			mesFilterFruits [i].transform.localScale = new Vector3 (tmpScale,tmpScale,tmpScale);
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

	Vector3 GetRotate(string fruitName)
	{
		switch (fruitName)
		{
		case "Corn":
			return new Vector3(0,90,0);
		case "Fish":
			return new Vector3(90,90,0);
		case "GreenPepper":
			return new Vector3(0,90,0);
		case "Meat":
			return new Vector3(90,90,0);
		case "Mushroom":
			return new Vector3(0,90,0);
		default:
			return new Vector3(0,90,0);
		}
	}

	float GetScale(string fruitName)
	{
		switch (fruitName)
		{
		case "Corn":
			return 1.0f;
		case "Fish":
			return 1.0f;
		case "GreenPepper":
			return 0.7f;
		case "Meat":
			return 0.7f;
		case "Mushroom":
			return 0.7f;
		default:
			return 1.0f;
		}
	}
}
