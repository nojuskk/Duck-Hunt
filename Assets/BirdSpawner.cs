using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour {

    public GameObject[] birdsLeft;
    public GameObject[] birdsRight;

    public float spawnTime = 1.5f;

    public int randomIndex = 3;

    void Start () {
        InvokeRepeating("Spawn", 0, spawnTime);
	}
	
	void Spawn()
    {
        randomIndex = Random.Range(0, 4);
            GameObject birdLeft = Instantiate(birdsLeft[randomIndex], new Vector3(11, Random.Range(-4, 4), 0), Quaternion.identity);
            GameObject birdRight = Instantiate(birdsRight[randomIndex], new Vector3(-11, Random.Range(-4, 4), 0), Quaternion.identity);
      
                

        Destroy(birdLeft, 5f);
        Destroy(birdRight, 5f);


    }
}
