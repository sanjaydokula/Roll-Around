using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwanner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spwanPoints;
    public GameObject asteroid;
    private GameObject enemy;
    private int spwanL;
    private float timeToSpawn;
    private float spawnRate = .5f;
    void Start()
    {

        spwanL = spwanPoints.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToSpawn)
        {
            Spawn();
            timeToSpawn = Time.time + 1 / spawnRate;
        }
    }
    public void Spawn()
    {
        int prand = 0;
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, spwanL);
            if (prand != rand)
            {
                enemy = Instantiate(asteroid, spwanPoints[rand].position, Quaternion.identity) as GameObject;
                Vector3 pos = (Vector3.zero - enemy.transform.position);
                //enemy.GetComponent<Rigidbody2D>().AddForce(pos * 10.0f);
                Destroy(enemy, 5);
                prand = rand;
            }
        }
    }
}
