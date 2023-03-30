using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]private float sensitivityX;

    [SerializeField]private float sensitivityY;

    [SerializeField]private Transform Orientation;

    private float RotationX;
    private float RotationY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivityY * Time.deltaTime;

        RotationY += mouseX;
        RotationX -= mouseY;

        RotationX = Mathf.Clamp(RotationX, -90f, 90f);
        transform.rotation = Quaternion.Euler(RotationX, RotationY, 0);

        Orientation.rotation = Quaternion.Euler(0, RotationY, 0);
    }
}
