using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public GameObject DoorOne;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask) && Input.GetKey(KeyCode.E) && DoorOne.name == "Door1")
        {
            player.position = new Vector3(-21.91f, 0.928f, -76.58f);
        }

    }
}
