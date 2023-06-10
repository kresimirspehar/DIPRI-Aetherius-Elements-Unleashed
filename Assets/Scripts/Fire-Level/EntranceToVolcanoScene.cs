using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceToVolcanoScene : MonoBehaviour
{
    [SerializeField] private GameObject uiElement;

  void OnTriggerEnter(Collider other) {
    //    if (other.CompareTag("Player"))
    //     {
    //         uiElement.SetActive(true);
    //     if(Input.GetKeyDown(KeyCode.E)){
         SceneManager.LoadScene(7);
        //  }
        //  }
     }

    //     private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         uiElement.SetActive(false);
    //     }
    // }
}
