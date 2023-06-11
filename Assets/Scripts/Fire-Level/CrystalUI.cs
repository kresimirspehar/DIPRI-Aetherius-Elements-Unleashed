using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalUI : MonoBehaviour
{
      public TextMeshProUGUI crystalText;
    // Start is called before the first frame update
    void Start()
    {
        crystalText = GetComponent<TextMeshProUGUI>();
    }

   public void UpdateCrystalText(PlayerInventoryForCrytals playerInventory){
    crystalText.text = playerInventory.numberOfCrystals.ToString();
   }
}
