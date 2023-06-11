// Skripta BookController
using UnityEngine;

public class BookController : MonoBehaviour
{
    public string bookHint; // Hint za knjigu

    private bool hasBeenCollected = false;
    private BookHintDisplay hintDisplay;

    private void Start()
    {
        hintDisplay = FindObjectOfType<BookHintDisplay>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenCollected && other.CompareTag("Player"))
        {
            CollectBook();
        }
    }

    private void CollectBook()
    {
        hasBeenCollected = true;

        if (hintDisplay != null)
        {
            hintDisplay.AddBookHint(bookHint);
        }

        // Dodajte ovdje kôd za uklanjanje knjige s scene ili deaktivaciju knjige
        gameObject.SetActive(false);
    }
}
