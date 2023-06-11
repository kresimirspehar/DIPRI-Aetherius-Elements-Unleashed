using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventoryForCrytals : MonoBehaviour
{
public int numberOfCrystals {get;  set;}

   public UnityEvent<PlayerInventoryForCrytals> OnCrystalCollected;

   public void CrystalCollected(){
    numberOfCrystals++;
    Debug.Log(numberOfCrystals);
    OnCrystalCollected.Invoke(this);
   }
}
