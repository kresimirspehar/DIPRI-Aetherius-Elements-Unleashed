using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventoryForTotem : MonoBehaviour
{
   public int numberOfTotem {get;  set;}

   public UnityEvent<PlayerInventoryForTotem> OnTotemCollected;

   public void TotemCollected(){
    numberOfTotem++;
    OnTotemCollected.Invoke(this);
   }
}
