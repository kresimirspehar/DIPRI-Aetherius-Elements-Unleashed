using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int healthAmount = 5;
    [SerializeField] float damageDelay = 1;
    [SerializeField] TextMeshProUGUI textHealth;
    private bool canTakeDamage = true;
    private bool isDead = false;

    void Update()
    {
        if (healthAmount <= 0 && !isDead)
        {
            isDead = true;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
    public void updateHealth(int value)
    {
        if (canTakeDamage)
        {
            healthAmount += value;
            textHealth.text = "Health: " + healthAmount;
            StartCoroutine(delayDamage());
        }
    }
    private IEnumerator delayDamage()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }
}
