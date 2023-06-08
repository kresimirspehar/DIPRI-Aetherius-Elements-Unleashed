using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGameplay : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2;

    public int maxSpawnedenemies = 2;
    private int spawnedEnemies = 0;

    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // do not spawn new enemies if max spawned
        if (spawnedEnemies >= maxSpawnedenemies) 
        {
            return;
        }

        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            spawnEnemy();
            timer = 0;
            spawnedEnemies++;
        }
    }

    public void decrementSpawnedEnemies()
    {
        spawnedEnemies--;
    }

    public void spawnEnemy() 
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
