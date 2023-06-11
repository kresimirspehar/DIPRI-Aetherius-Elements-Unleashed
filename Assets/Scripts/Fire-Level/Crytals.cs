using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crytals : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
 {
    PlayerInventoryForCrytals playerInventory = other.GetComponent<PlayerInventoryForCrytals>();
     if(playerInventory != null){
        playerInventory.CrystalCollected();
        gameObject.SetActive(false);
     }
 }
}
