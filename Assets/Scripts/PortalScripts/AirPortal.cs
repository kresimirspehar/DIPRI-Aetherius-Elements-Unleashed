using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
         PlayerInventoryForTotem playerInventory = other.GetComponent<PlayerInventoryForTotem>();
        if(playerInventory.numberOfTotem == 1){
        SceneManager.LoadScene(5);
        }
        else {
            Scene currentScene = SceneManager.GetActiveScene();
        }
    }
}
