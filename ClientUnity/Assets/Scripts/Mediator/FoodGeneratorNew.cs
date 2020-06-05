using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneratorNew : MonoBehaviour
{
    public Transform FruitMother;
    public List<GameObject> FruitCreated;
    public GameObject[] FruitKind;
    public Vector3[] FruitPos;
    public int MaxCount = 20;
    public AudioClip FullingSound;



    int FruitListIndex = 0;


	void Start()
    {
        Reset();
        GameLogic.GetInstance().GeneratorMediator.Regist_FoodGenerator(GetComponent<FoodGeneratorNew>());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Reset();
        }
    }

    public void Init()
    {

    }

    public void CreatFruits()
    {
        if (FruitCreated.Count < MaxCount)
        {
            for (int i = 0; i < Random.Range(2, 5); i++)
            {
                GameObject Fruits = Instantiate(FruitKind[Random.Range(0, FruitKind.Length)], new Vector3(Random.Range(-10, 10), 20, Random.Range(-10, 10)), Quaternion.Euler(0, Random.Range(0, 360), 0), FruitMother);
                FruitCreated.Add(Fruits);
			}
			GetComponent<AudioSource>().PlayOneShot(FullingSound);
        }
    }

    public void KillFruit(GameObject Fruit)
    {
        FruitCreated.Remove(Fruit);
        Destroy(Fruit);
    }

    public void AutoKillFruit(GameObject Fruit)
    {
        FruitCreated.Remove(Fruit);
        Destroy(Fruit);

        //FruitCreated.Remove(Fruit);
        //Destroy(Fruit);

        /*
        if (FruitListIndex < 3)
        {
            FruitCreated.RemoveAt(FruitListIndex);
            Destroy(Fruit);
            FruitListIndex += 1;
        }
        else
        {
            FruitListIndex = 0;
            FruitCreated.RemoveAt(FruitListIndex);
            Destroy(Fruit);
            FruitListIndex += 1;
        }
        */


    }

    public void Reset()
    {
        for (int i = 0; i < FruitCreated.Count; i++)
        {
            Destroy(FruitCreated[i]);
        }
        FruitCreated.Clear();
        if (FruitCreated.Count < MaxCount)
        {
            for (int i = 0; i < Random.Range(7, 10); i++)
            {
                GameObject Fruits = Instantiate(FruitKind[Random.Range(0, FruitKind.Length)], new Vector3(Random.Range(-10, 10), 20, Random.Range(-10, 10)), Quaternion.Euler(0, Random.Range(0, 360), 0), FruitMother);
                FruitCreated.Add(Fruits);
			}
			GetComponent<AudioSource>().PlayOneShot(FullingSound);
        }
    }




}