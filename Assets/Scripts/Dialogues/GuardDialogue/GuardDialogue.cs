using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuardDialogue : MonoBehaviour
{

    public TextMeshProUGUI DialogueText, objectiveText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool NextText = true;
    public GameObject defaultIcon, ammunitionDisplay, responsePanel, controller;
    public AudioSource DialogueSound;



    // Update is called once per frame
    void Update()
    {
        defaultIcon.SetActive(false);
        ammunitionDisplay.SetActive(false);
        StartDialogue = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {

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
            responsePanel.SetActive(true);
            controller.SetActive(false);
        }
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
