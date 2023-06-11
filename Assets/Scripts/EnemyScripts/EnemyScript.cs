using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPositions = new();
    [SerializeField] private float walkingSpeed = 10f;
    [SerializeField] private float distanceToStop = 2;
    [SerializeField] private float searchDistance = 8;
    private bool arrivedAtPosition = false;
    private int currentPosition = 0;
    private Rigidbody rb;
    private Transform rotation;
    private Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Gače");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(player);
        rotation = transform.GetChild(0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 enemyPosition = new(transform.position.x, 0, transform.position.z);
        Vector3 playerPosition = new(player.position.x, 0, player.position.z);
        if (Vector3.Distance(enemyPosition, playerPosition) < searchDistance)
        {
            Debug.Log("Gače");
            lookAt(player);
            followTarget(player, 1, walkingSpeed * 1.5f);
        }
        else if (!arrivedAtPosition)
        {
            lookAt(patrolPositions[currentPosition]);
            followTarget(patrolPositions[currentPosition], distanceToStop, walkingSpeed);
        }
        else
        {
            currentPosition = (currentPosition + 1) % patrolPositions.Count;
            arrivedAtPosition = false;
        }
    }
    private void lookAt(Transform target)
    {
        Vector3 targetPosition = new(target.position.x, target.position.y, target.position.z);
        rotation.LookAt(targetPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation.rotation, 0.15f);
    }
    private void followTarget(Transform target, float stopingDistance, float movingSpeed)
    {
        Vector3 enemyPosition = new(transform.position.x, 0, transform.position.z);
        Vector3 targetPosition = new(target.position.x, 0, target.position.z);
        if (Vector3.Distance(enemyPosition, targetPosition) > stopingDistance)
        {
            rb.AddRelativeForce(Vector3.forward * movingSpeed, ForceMode.Acceleration);
        }
        else
        {
            arrivedAtPosition = true;
        }
    }
}
