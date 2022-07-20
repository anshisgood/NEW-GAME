using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndianEnter : MonoBehaviour
{

    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool NextText = true;
    public GameObject IndianDialogue, player, defaultIcon, ammunitionDisplay, IndianCam, objectiveDisplay;
    public AudioSource DialogueSound;



    // Update is called once per frame
    void Update()
    {
        player.SetActive(false);
        IndianCam.SetActive(true);
        defaultIcon.SetActive(false);
        ammunitionDisplay.SetActive(false);
        objectiveDisplay.SetActive(false);


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
        IndianDialogue.SetActive(false);
        IndianCam.SetActive(false);
        player.SetActive(true);
        defaultIcon.SetActive(true);
        ammunitionDisplay.SetActive(true);
        objectiveDisplay.SetActive(true);
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
