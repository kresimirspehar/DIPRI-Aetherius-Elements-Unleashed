using UnityEngine;

public class Villager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string interactionMessage = "Press [E] to interact";
    private bool first = false;
    private bool canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            first=false;
            canInteract = true;
            dialogueManager.DisplayInteractionMessage(interactionMessage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            dialogueManager.EndDialogue();
            canInteract = false;
            dialogueManager.ClearInteractionMessage();
        }
    }

    private void Update()
    {
        if (!first && canInteract && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.StartDialogue();
            first=true;
        }
        if(canInteract&&Input.GetKeyDown(KeyCode.E)){
            dialogueManager.DisplayNextLine();
        }
    }
}
