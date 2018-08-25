using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {


    // The target marker.
    //public GameObject Playground;

    public GameObject Food1;
    public GameObject Food2;
    public GameObject Food3;
    public GameObject Food4;
    public GameObject Food5;

    public int DropSpeed = 2;

    public 

    // Use this for initialization
    void Start () {


        Initi();
        
    }

    public void Initi(){


        //消除方法


        //初始位置


        for (int i = 0; i < 5; i++)
        {
           
                GameObject FoodDrop1 = Instantiate(Food1) as GameObject;

                GameObject FoodDrop2 = Instantiate(Food2) as GameObject;

                GameObject FoodDrop3 = Instantiate(Food3) as GameObject;

                GameObject FoodDrop4 = Instantiate(Food4) as GameObject;

                GameObject FoodDrop5 = Instantiate(Food5) as GameObject;


                float f1 = UnityEngine.Random.Range(0.0f, 10.0f);
                float f2 = UnityEngine.Random.Range(0.0f, 10.0f);
                float f3 = UnityEngine.Random.Range(0.0f, 10.0f);
                float f4 = UnityEngine.Random.Range(0.0f, 10.0f);
                float f5 = UnityEngine.Random.Range(0.0f, 10.0f);


                FoodDrop1.transform.position = new Vector3(f2, 20, -f1);
                FoodDrop2.transform.position = new Vector3(f5, 20, -f1);
                FoodDrop3.transform.position = new Vector3(f3, 20, -f4);
                FoodDrop4.transform.position = new Vector3(f1, 20, -f5);
                FoodDrop5.transform.position = new Vector3(f4, 20, -f3);

                //FoodDrop.transform.position = new Vector3(0, DropSpeed , 5);

                // The step size is equal to speed times frame time.
                //float Speed = DropSpeed * Time.deltaTime;

                // Move our position a step closer to the target.
                //Food.transform.position = Vector3.MoveTowards(Food.transform.position, Playground.transform.position, Speed);



        }




    }

    // Update is called once per frame
    void Update () {
        
    }

    //For Timer
    public void GenerateAccordingTime(){

        Initi();
    }


}

