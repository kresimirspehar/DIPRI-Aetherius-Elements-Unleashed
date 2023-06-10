using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForCollect : MonoBehaviour
{
 private void OnTriggerEnter(Collider other)
 {
    PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
    // if(playerInventory != null){
        Debug.Log("proba");
        playerInventory.EarthTotemCollected();
        gameObject.SetActive(false);
    // }
 }
}
