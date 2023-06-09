using UnityEngine;
using TMPro;

public class CharacterDialogue : MonoBehaviour
{
    public GameObject dialogueCanvas; // Reference to the UI canvas with the TextMeshProUGUI component
    public string dialogueText; // The text you want to display in the dialogue
    public float interactionRange = 3f; // The range at which the player can interact with the character

    private bool isPlayerInRange; // Flag to track if the player is within range
    private bool isDialogueActive; // Flag to track if the dialogue is currently active
    private Transform playerTransform; // Reference to the player's transform component

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (isPlayerInRange && !isDialogueActive && distanceToPlayer <= interactionRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
        }
        else if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            HideDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            HideDialogue();
        }
    }

    private void ShowDialogue()
    {
        dialogueCanvas.SetActive(true);
        dialogueCanvas.GetComponentInChildren<TextMeshProUGUI>().text = dialogueText;
        isDialogueActive = true;
    }

    private void HideDialogue()
    {
        dialogueCanvas.SetActive(false);
        isDialogueActive = false;
    }
}
