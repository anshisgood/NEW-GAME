using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuardDialogue3 : MonoBehaviour
{

    public TextMeshProUGUI DialogueText, objectiveText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool NextText = true;
    public GameObject GuardDialogue, player, defaultIcon, ammunitionDisplay, DialogueCam, objectiveDisplay, GuardGun, GuardDefault;
    public AudioSource DialogueSound;



    // Update is called once per frame
    void Update()
    {

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
            DialogueAnimator.SetTrigger("Exit");
            StartCoroutine(wait());
            DialogueText.text = "";
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.8f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GuardDialogue.SetActive(false);
        DialogueCam.SetActive(false);
        player.SetActive(true);
        defaultIcon.SetActive(true);
        ammunitionDisplay.SetActive(true);
        objectiveDisplay.SetActive(true);
        objectiveText.text = "Objective: Find a way to break in";
        GuardGun.SetActive(false);
        GuardDefault.SetActive(true);
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
