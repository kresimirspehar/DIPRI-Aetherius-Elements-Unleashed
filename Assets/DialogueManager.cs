using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI interactionText;

    public string[] dialogueLines;
    private int currentLineIndex = 0;
    private bool dialogueActive = false;
    private bool isDisplayingLine = false;
    private float letterDelay = 0.05f;

    private void Start()
    {
        dialogueText.gameObject.SetActive(false);
        interactionText.gameObject.SetActive(false);
    }

    public void StartDialogue()
    {
        currentLineIndex = 0;
        dialogueActive = true;
        dialogueText.gameObject.SetActive(true);
        interactionText.gameObject.SetActive(false);
    }

    public void DisplayNextLine()
    {
        if (isDisplayingLine)
        {
            StopAllCoroutines();
            setInteraction(false);
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++;
            isDisplayingLine = false;
        }
        else
        {
            if (currentLineIndex < dialogueLines.Length)
            {
                setInteraction(true);
                StartCoroutine(DisplayLineByLetter(dialogueLines[currentLineIndex]));
                currentLineIndex++;
            }
            else
            {
                EndDialogue();
            }
        }
    }

    private System.Collections.IEnumerator DisplayLineByLetter(string line)
    {
        isDisplayingLine = true;
        dialogueText.text = string.Empty;

        for (int i = 0; i < line.Length; i++)
        {
            dialogueText.text += line[i];
            yield return new WaitForSeconds(letterDelay);
        }

        isDisplayingLine = false;
        setInteraction(false);
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        currentLineIndex = 0;
        dialogueActive = false;
        isDisplayingLine = false;
        dialogueActive = false;
        dialogueText.gameObject.SetActive(false);       
        DisplayInteractionMessage("Now go search for the key!");
    }

    public void DisplayInteractionMessage(string message)
    {
        interactionText.text = message;
        interactionText.gameObject.SetActive(true);
    }

    public void ClearInteractionMessage()
    {
        interactionText.gameObject.SetActive(false);
    }
    public void setInteraction(bool state)
    {
    if (!state && dialogueActive)
    {
        StartCoroutine(DelayedInteraction());
    }
    else
    {
        interactionText.gameObject.SetActive(false);
    }
    }

    private System.Collections.IEnumerator DelayedInteraction()
    {
        yield return new WaitForSeconds(0.4f); 
        
        interactionText.text = "Press [E] to continue interaction";
        interactionText.gameObject.SetActive(true);
    }

}
