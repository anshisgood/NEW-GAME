using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public GameObject player, IndianDialogue, IndianCam;



    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
            {
                if (hit.collider.gameObject.name == "Body")
                {
                    player.SetActive(false);
                    IndianDialogue.SetActive(true);
                    IndianCam.SetActive(true);

                }

            }

        }
    }
}
