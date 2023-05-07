using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
     public TextMeshProUGUI earthTotemText;
    // Start is called before the first frame update
    void Start()
    {
        earthTotemText = GetComponent<TextMeshProUGUI>();
    }

   public void UpdateTotemText(PlayerInventory playerInventory){
    earthTotemText.text = playerInventory.CollectEarthTotem.ToString();
   }
}
