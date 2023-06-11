using UnityEngine;

public class CrystalLightController : MonoBehaviour
{
    public GameObject player;
    public Light crystalLight;

    private void Start()
    {
        // Ensure the crystal light is initially deactivated
        crystalLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject == player)
        {
            // Player is nearby, activate the crystal light
            crystalLight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject == player)
        {
            // Player has moved away, deactivate the crystal light
            crystalLight.enabled = false;
        }
    }
}
