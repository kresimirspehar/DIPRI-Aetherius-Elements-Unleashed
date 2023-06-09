using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private int coinAmount = 0;
    [SerializeField] private TextMeshProUGUI textCoinAmount;
    public AudioSource coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinAmount++;
            textCoinAmount.text = "Total coins: " + coinAmount;
            coinSound.Play();
            Destroy(other.gameObject);
        }
    }
}
