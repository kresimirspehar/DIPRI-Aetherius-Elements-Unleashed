using UnityEngine;
using TMPro;

public class KeyHover : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject hoverTextObject;
    public bool pickup=false;
    public string message = "Press E to obtain the key";
    public Vector3 offset = new Vector3(0f, 2f, 0f);

    private bool isHovering = false;

    private void Start()
    {
        hoverTextObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isHovering = true;
            hoverTextObject.SetActive(true);
            SetHoverTextPosition();
            SetHoverTextMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isHovering = false;
            hoverTextObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isHovering && Input.GetKeyDown(KeyCode.E))
        {
            PickupKey();
        }

        if (isHovering)
        {
            SetHoverTextPosition();
        }
    }

    private void SetHoverTextPosition()
    {
        Vector3 targetPosition = transform.position + offset;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetPosition);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        hoverTextObject.transform.position = worldPosition;
    }

    private void SetHoverTextMessage()
    {
        TextMeshProUGUI hoverText = hoverTextObject.GetComponentInChildren<TextMeshProUGUI>();
        if (hoverText != null)
        {
            hoverText.text = message;
        }
        if(pickup){
            hoverText.text="Castle door's are now open,\n\n head to the castle!";
            hoverText.fontSize=0.24f;
        }
    }

    private void PickupKey()
    {
        pickup=true;
        DestroyCubes();
        SetHoverTextMessage();
        gameObject.SetActive(false);
    }
     void DestroyCubes()
    {
        foreach(var cube in cubes){
            Destroy(cube.gameObject);
            Debug.Log(cube.gameObject.name);}
    }
}
