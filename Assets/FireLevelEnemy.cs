using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLevelEnemy : MonoBehaviour
{
    private GameObject player;
    private FireGameplay gameplaySpawnerScript; 


    public float movementSpeed = 10;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameplaySpawnerScript = GameObject.FindGameObjectWithTag("volcane").GetComponent<FireGameplay>();
    }

    // Update is called once per frame
    void Update()
    {
        // destory enemy when in range of player - should maybe deal damage to player
        if (Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            Destroy(gameObject);
            gameplaySpawnerScript.decrementSpawnedEnemies();
        }


        enemyMovement();

    }


    void enemyMovement() 
    {
        // enemy move towards player position
        transform.position = Vector3.MoveTowards( transform.position, player.transform.position, movementSpeed * Time.deltaTime );
        transform.LookAt( player.transform.position, Vector3.up );
    }
}
