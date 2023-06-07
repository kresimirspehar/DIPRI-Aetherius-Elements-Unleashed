using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject[] cubes;

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E))
        {
            PickupKey();
            DestroyCubes();
        }
    }

    void PickupKey()
    {
        gameObject.SetActive(false);
    }

    void DestroyCubes()
    {
        foreach(var cube in cubes){
            Destroy(cube.gameObject);
            Debug.Log(cube.gameObject.name);}
    }
}
