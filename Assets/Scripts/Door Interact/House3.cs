using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class House3 : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public Transform player;
    [SerializeField] private Animator Image;
    [SerializeField] private string fade = "FadeIn";
    public GameObject IndianMan, IndianEnter, interactPanel, playerCam, playerDisable;
    public TextMeshProUGUI objective, interactText;


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

                if (hit.collider.gameObject.name == "Door_2")
                {
                    player.position = new Vector3(-26.4799995f, 1.67999995f, -153.444f);
                    Image.Play(fade, 0, 0.0f);
                    IndianMan.GetComponent<Outline>().enabled = true;
                    objective.text = "Objective: Talk to the Indian man";
                    IndianEnter.SetActive(true);

                }

            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
            {

                if (hit.collider.gameObject.name == "Door_02")
                {
                    interactPanel.SetActive(true);
                    interactText.text = "The Desi Crew is currently not open to visitors.";
                    playerDisable.SetActive(false);
                    playerCam.GetComponent<PlayerCam>().enabled = false;
                    StartCoroutine(Delay());
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
    }
}