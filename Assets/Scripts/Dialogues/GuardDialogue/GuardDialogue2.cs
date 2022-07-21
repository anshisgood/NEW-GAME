using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuardDialogue2 : MonoBehaviour
{

    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool NextText = true;
    public GameObject GuardDialogue, Guard2Dialogue;
    public AudioSource DialogueSound;
    public Animator CameraSwitch;



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
            CameraSwitch.enabled = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.8f);
        Guard2Dialogue.SetActive(true);
        GuardDialogue.SetActive(false);
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
