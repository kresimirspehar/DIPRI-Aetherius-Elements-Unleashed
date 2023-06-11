using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireTtotemUI : MonoBehaviour
{
      public TextMeshProUGUI totemText;
    // Start is called before the first frame update
    void Start()
    {
        totemText = GetComponent<TextMeshProUGUI>();
    }

   public void UpdateTotemText(PlayerInventoryForTotem playerInventory){
    totemText.text = playerInventory.numberOfTotem.ToString();
   }
}
