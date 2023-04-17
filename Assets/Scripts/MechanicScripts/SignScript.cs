using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignScript : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private TextMeshProUGUI textGUI;
    [SerializeField] private string text = "";
    private Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, Player.position) < 2f)
            {
                if (!textBox.activeSelf)
                {
                    textBox.SetActive(true);
                    textGUI.text = text;
                    Player.GetComponent<PlayerMovement>().canMove(false);
                }
                else
                {
                    textBox.SetActive(false);
                    Player.GetComponent<PlayerMovement>().canMove(true);
                }
            }
        }
    }
}
