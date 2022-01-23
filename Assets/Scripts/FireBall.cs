using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Transform[] spawnPoint;

    public GameObject fireBall;

    public float timeBetweenWave = 1f;

    private float timeToSpawn = 2f;

    public bool isStart = false;
    // Start is called before the first frame update
    void Update()
    {
        if (isStart)
        {
            if (Time.time >= timeToSpawn)
            {
                SpawnBlock();
                timeToSpawn = Time.time + timeBetweenWave;
            }
        }

    }

    void SpawnBlock()
    {
        int randomIndex = Random.Range(0, spawnPoint.Length);
        int fire = Random.Range(0, spawnPoint.Length);
        while (fire == randomIndex){
            fire = Random.Range(0, spawnPoint.Length);
        }
        Debug.Log(fire);
        Debug.Log(randomIndex);
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            if (randomIndex != i)
            {
                if (fire!=i)
                    Instantiate(fireBall, spawnPoint[i].position, Quaternion.identity);
            }
        }
    }

  

}
