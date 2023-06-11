using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light crystalLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crystalLight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crystalLight.enabled = false;
        }
    }
}
