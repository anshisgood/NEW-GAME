using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnDoor : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public GameObject DoorOne;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
            {

                if (hit.collider.gameObject.name == "SpawnRoomDoor")
                {
                    SceneManager.LoadScene("Town");
                    DoorOne.GetComponent<Outline>().enabled = false;


                }

            }

        }
    }
}
