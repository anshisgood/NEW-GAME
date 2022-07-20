using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Drawer2 : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public GameObject player, playerCam, InteractPanel, objectiveDisplay, decisionPanel, grandmaCam, noDecision, defaultIcon, ammunitionDisplay, closet, door, drawer, doorScript;
    public TextMeshProUGUI InteractText, objectiveText;


    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
            {

                if (hit.collider.gameObject.name == "Drawer02")
                {
                    InteractText.text = "A drawer containing pictures of your favorite idol.";
                    InteractPanel.SetActive(true);
                    player.SetActive(false);
                    playerCam.GetComponent<PlayerCam>().enabled = false;
                    StartCoroutine(Decision());

                }

            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
            {

                if (hit.collider.gameObject.name == "Drawer002")
                {
                    InteractText.text = "It's Empty.";
                    InteractPanel.SetActive(true);
                    player.SetActive(false);
                    playerCam.GetComponent<PlayerCam>().enabled = false;
                    drawer.name = "Drawer002";
                    StartCoroutine(Delay());

                }

            }

        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1.5f);
            InteractPanel.SetActive(false);
            player.SetActive(true);
            playerCam.GetComponent<PlayerCam>().enabled = true;
        }

        IEnumerator Decision()
        {
            yield return new WaitForSeconds(2);
            InteractPanel.SetActive(false);
            decisionPanel.SetActive(true);
            objectiveDisplay.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            drawer.name = "Drawer002";
        }

    }

    public void YesOption()
    {
        player.SetActive(true);
        playerCam.GetComponent<PlayerCam>().enabled = true;

        closet.GetComponent<Outline>().enabled = false;
        door.GetComponent<Outline>().enabled = true;

        objectiveDisplay.SetActive(true);
        objectiveText.text = "Objective: Explore the city and find a way to calm that bitch down.";

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        decisionPanel.SetActive(false);
        doorScript.GetComponent<SpawnDoor>().enabled = true;
    }

    public void NoOption()
    {
        ammunitionDisplay.SetActive(false);
        defaultIcon.SetActive(false);

        playerCam.SetActive(false);
        grandmaCam.SetActive(true);

        noDecision.SetActive(true);
        decisionPanel.SetActive(false);
    }
}
