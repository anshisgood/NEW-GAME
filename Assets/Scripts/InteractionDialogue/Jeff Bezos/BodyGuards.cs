using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BodyGuards : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public GameObject interactPanel, playerDisable, playerCam, robBezos, sign, guards, collider, GuardDialogue, playerFull, Guardcam, AggresedGuard, defaultGuard;
    public TextMeshProUGUI interactText;
    public Outline houseOutline;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (robBezos.name == "RobBezos?")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2))
                {
                    if (hit.collider.gameObject.name == "InteractableThing" || hit.collider.gameObject.name == "InteractableThing (1)")
                    {
                        interactPanel.SetActive(true);
                        interactText.text = "The guards will not let you in.";
                        playerDisable.SetActive(false);
                        playerCam.GetComponent<PlayerCam>().enabled = false;
                        StartCoroutine(Delay());
                    }
                }

            }
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1.5f);
            playerDisable.SetActive(true);
            playerCam.GetComponent<PlayerCam>().enabled = true;
            interactPanel.SetActive(false);
        }

        if (robBezos.name == "No")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2))
                {
                    if (hit.collider.gameObject.name == "InteractableThing" || hit.collider.gameObject.name == "InteractableThing (1)")
                    {
                        playerFull.SetActive(false);
                        GuardDialogue.SetActive(true);
                        Guardcam.SetActive(true);
                        AggresedGuard.SetActive(true);
                        defaultGuard.SetActive(false);
                        houseOutline.enabled = false;
                    }
                }

            }
        }

        if (robBezos.name == "Yes")
        {
            // Guards on lunch break
            guards.SetActive(false);
            sign.SetActive(true);         
            collider.SetActive(false);
        }
    }
}