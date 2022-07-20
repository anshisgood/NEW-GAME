using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NoDecision : MonoBehaviour
{

    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool NextText = true;
    public AudioSource DialogueSound, GunShot;
    public GameObject responsePanel, noDecisionPanel, grandmaCam, grandmaCam2, doorScript, objectiveDisplay, closet, door, player, playerCam, ammunitionDisplay, defaultIcon, pistol, black, contents, uLose;
    public TextMeshProUGUI objectiveText;
    public Animator GrandmaTurn;



    // Update is called once per frame
    void Update()
    {

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
            NextText = true;
            responsePanel.SetActive(true);
        }
    }

    public void SorryGrandma()
    {
        player.SetActive(true);
        playerCam.GetComponent<PlayerCam>().enabled = true;
        playerCam.SetActive(true);

        closet.GetComponent<Outline>().enabled = false;
        door.GetComponent<Outline>().enabled = true;

        objectiveDisplay.SetActive(true);
        objectiveText.text = "Objective: Explore the city and find a way to calm Grandma down";

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        doorScript.GetComponent<SpawnDoor>().enabled = true;
        grandmaCam.SetActive(false);

        noDecisionPanel.SetActive(false);
        responsePanel.SetActive(false);

        ammunitionDisplay.SetActive(true);
        defaultIcon.SetActive(true);
    }

    public void ShutUpGrandma()
    {
        StartCoroutine(GrandmaAnimated());
    }

    IEnumerator GrandmaAnimated()
    {
        yield return new WaitForSeconds(2);
        GrandmaTurn.enabled = true;
        yield return new WaitForSeconds(2);
        grandmaCam.SetActive(false);
        grandmaCam2.SetActive(true);
        responsePanel.SetActive(false);
        contents.SetActive(false);
        pistol.SetActive(true);
        yield return new WaitForSeconds(2);
        GunShot.enabled = true;
        black.SetActive(true);
        uLose.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
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
