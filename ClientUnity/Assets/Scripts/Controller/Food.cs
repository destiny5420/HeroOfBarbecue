using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{

    float killRate = 20.0f;
    float timer = 0;

    public AudioClip soundDrop;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        if(timer < killRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            GameLogic.GetInstance().GeneratorMediator.Kill_Fruit(gameObject);

            //Destroy(gameObject);
            timer = 0;
        }


	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Playground")
        {
            Debug.Log("Hit");
            GetComponent<AudioSource>().PlayOneShot(soundDrop);
        }

    }


}
