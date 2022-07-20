using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndianWithAHat : MonoBehaviour
{

    public TextMeshProUGUI DialogueText, objectiveText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool NextText = true;
    public GameObject IndianDialogue, player, defaultIcon, ammunitionDisplay, IndianCam, objectiveDisplay, response, Indianguy, door, cube1, cube2, RobBezos, dooragain;
    public AudioSource DialogueSound;



    // Update is called once per frame
    void Update()
    {
        defaultIcon.SetActive(false);
        ammunitionDisplay.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDialogue = false;
            if (StartDialogue)
            {

                DialogueAnimator.SetTrigger("Enter");
            }
            else
            {
                if (NextText)
                {
                    NextSentence();
                }

            }
        }

        if (NextText == false)
        {
            DialogueSound.enabled = true;
        }
        else
        {
            DialogueSound.enabled = false;
        }

    }

    void NextSentence()
    {
        if (Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
            NextText = false;
        }
        else
        {
            StartDialogue = true;
            NextText = true;
            StartCoroutine(wait());

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.8f);
        response.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        /// IndianDialogue.SetActive(false);
        ///   IndianCam.SetActive(false);
        /// player.SetActive(true);
        /// defaultIcon.SetActive(true);
        /// ammunitionDisplay.SetActive(true);
        // objectiveDisplay.SetActive(true);
    }

    IEnumerator yesOption()
    {
        DialogueText.text = "";
        DialogueAnimator.SetTrigger("Exit");
        yield return new WaitForSeconds(0.8f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IndianDialogue.SetActive(false);
        response.SetActive(false);
        IndianCam.SetActive(false);
        player.SetActive(true);
        defaultIcon.SetActive(true);
        ammunitionDisplay.SetActive(true);
        objectiveDisplay.SetActive(true);
        objectiveText.text = "Objective: Go Rob Jeff Bezos";
        Indianguy.GetComponent<Outline>().enabled = false;
        Indianguy.GetComponent<DialogueInteract>().enabled = false;
        door.GetComponent<Outline>().enabled = true;
        dooragain.name = "PFB_DoorLeave";
        RobBezos.name = "Yes";
    }


    IEnumerator noOption()
    {
        DialogueText.text = "";
        DialogueAnimator.SetTrigger("Exit");
        yield return new WaitForSeconds(0.8f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IndianDialogue.SetActive(false);
        response.SetActive(false);
        IndianCam.SetActive(false);
        player.SetActive(true);
        defaultIcon.SetActive(true);
        ammunitionDisplay.SetActive(true);
        objectiveDisplay.SetActive(true);
        objectiveText.text = "Objective: Find Jeff";
        Indianguy.GetComponent<Outline>().enabled = false;
        Indianguy.GetComponent<DialogueInteract>().enabled = false;
        cube1.SetActive(true);
        cube2.SetActive(true);
        RobBezos.name = "No";
        dooragain.name = "PFB_DoorLeave";
    }

    public void Yes()
    {
        StartCoroutine(yesOption());

    }

    public void No()
    {
        StartCoroutine(noOption());
    }

    IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        Index++;
        NextText = true;


    }
}
