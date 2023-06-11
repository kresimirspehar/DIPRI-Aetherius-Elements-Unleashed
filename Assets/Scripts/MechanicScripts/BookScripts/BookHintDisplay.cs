// Skripta BookHintDisplay
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class BookHintDisplay : MonoBehaviour
{
    public TextMeshProUGUI hintLabel; // Referenca na TextMeshProUGUI objekt za prikaz hintova

    private List<string> bookHints = new List<string>(); // Lista hintova za knjige

    private void Start()
    {
        UpdateHintText();
    }

    public void AddBookHint(string hint)
    {
        bookHints.Add(hint);
        UpdateHintText();
    }

    private void UpdateHintText()
    {
        if (hintLabel != null)
        {
            hintLabel.text = string.Join("\n", bookHints.ToArray());
        }
    }
}
