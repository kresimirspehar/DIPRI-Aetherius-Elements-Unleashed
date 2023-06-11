using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTotem : MonoBehaviour
{
      private void OnTriggerEnter(Collider other)
 {
    PlayerInventoryForTotem playerInventory = other.GetComponent<PlayerInventoryForTotem>();
     if(playerInventory != null){
        playerInventory.TotemCollected();
        gameObject.SetActive(false);
     }
 }
}
