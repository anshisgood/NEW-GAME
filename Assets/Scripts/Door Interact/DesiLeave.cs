using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DesiLeave : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public Transform player;
    [SerializeField] private Animator Image;
    [SerializeField] private string fade = "FadeIn";
    public GameObject House3, interactPanel, playerDisable, playerCam;
    public Outline Door, JeffHouse;
    public TextMeshProUGUI interactText;


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
                if(hit.collider.gameObject.name == "PFB_DoorDouble")
                {
                    interactPanel.SetActive(true);
                    interactText.text = "Talk to the Indian man.";
                    playerDisable.SetActive(false);
                    playerCam.GetComponent<PlayerCam>().enabled = false;
                    StartCoroutine(Delay());
                }
                if (hit.collider.gameObject.name == "PFB_DoorLeave")
                {
                    player.position = new Vector3(-22.3500004f, 3.5999999f, -77.4000015f);
                    Image.Play(fade, 0, 0.0f);
                    Door.enabled = false;
                    House3.name = "Door_02";
                    JeffHouse.enabled = true;
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