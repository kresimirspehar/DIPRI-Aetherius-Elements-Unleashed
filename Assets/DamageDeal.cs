using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDeal : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    private HealthScript playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindAnyObjectByType<HealthScript>();
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.updateHealth(-damageAmount);
        }
    }
}
