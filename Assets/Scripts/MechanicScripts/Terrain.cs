using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TerrainCollider>().enabled = true;  
    }

    // Update is called once per frame
    void Awake()
    {
      GetComponent<TerrainCollider>().enabled = false;  
    }
}
