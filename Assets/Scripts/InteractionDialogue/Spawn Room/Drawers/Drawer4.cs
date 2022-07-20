using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Drawer4 : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public GameObject player, playerCam, InteractPanel;
    public TextMeshProUGUI InteractText;



    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
            {

                if (hit.collider.gameObject.name == "Drawer04")
                {
                    InteractText.text = "Nothing but clothes.";
                    InteractPanel.SetActive(true);
                    player.SetActive(false);
                    playerCam.GetComponent<PlayerCam>().enabled = false;
                    StartCoroutine(Delay());


                }

            }

        }


        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1.5f);
            player.SetActive(true);
            playerCam.GetComponent<PlayerCam>().enabled = true;
            InteractPanel.SetActive(false);

        }
    }
}
