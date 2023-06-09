using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour



{
    public float rotationSpeed = 10f;
    public Vector3 rotationAxis = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        }
    }
}
