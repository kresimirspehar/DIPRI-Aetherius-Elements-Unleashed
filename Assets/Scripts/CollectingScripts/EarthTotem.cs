using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTotem : MonoBehaviour
{
 private void OnTriggerEnter(Collider other)
 {
    PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
   
    if(playerInventory != null){
        playerInventory.EarthTotemCollected();
        gameObject.SetActive(false);
    }
 }
}
