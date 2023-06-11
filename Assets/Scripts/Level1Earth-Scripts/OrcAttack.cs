using UnityEngine;

public class OrcAttack : MonoBehaviour
{
    public float idleTime = 3f; // Time the troll stays idle before chasing again
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    private Transform player;
    private bool isChasing = false;
    private bool isIdle = false;
    private float idleTimer = 0f;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the player is within chase range
        if (Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            isChasing = true;
            isIdle = false;
        }
        else
        {
            isChasing = false;
        }

        // Handle idle state
        if (isIdle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                idleTimer = 0f;
                isIdle = false;
            }
        }

        // Chase and attack the player
        if (isChasing)
        {
            // Rotate towards the player's position
            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move towards the player
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Check if the player is within attack range
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
            }
        }
        else if (!isIdle)
        {
            // Enter idle state
            Idle();
        }
    }

    private void Idle()
    {
        // Play idle animation
        animator.SetTrigger("Idle");

        // Perform any other idle actions
        // You can customize this method to fit your game's idle logic
        Debug.Log("Troll is idle");
        isIdle = true;
    }

    private void AttackPlayer()
    {
        // Perform the attack
        // You can customize this method to fit your game's attack logic
        Debug.Log("Troll attacks player!");
    }
}
