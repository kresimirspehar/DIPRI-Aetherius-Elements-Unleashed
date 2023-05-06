using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
   public int CollectEarthTotem {get; private set;}

   public UnityEvent<PlayerInventory> OnEarthTotemCollected;

   public void EarthTotemCollected(){
    CollectEarthTotem++;
    OnEarthTotemCollected.Invoke(this);
   }
}
