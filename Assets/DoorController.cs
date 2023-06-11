using UnityEngine;
using TMPro;
public class DoorController : MonoBehaviour
{
    private bool IsAtDoor = false;
    [SerializeField] private TextMeshProUGUI CodeText;
    string codeTextValue = "";
    public string safeCode;
    public GameObject CodePanel;
    private GameObject vrata;

    void Start()
    {
        vrata = GameObject.FindWithTag("airDoor");
    }
    void Update()
    {
        CodeText.text = codeTextValue;

        if (codeTextValue == safeCode)
        {
            Destroy(vrata);
            IsAtDoor = false;
            CodePanel.SetActive(false);
        }

        if (codeTextValue.Length > 4)
        {
            codeTextValue = "";
        }
        if (Input.GetKey(KeyCode.E) && IsAtDoor == true)
        {
            CodePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
