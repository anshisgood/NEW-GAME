using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuardRespond : MonoBehaviour
{

    public TextMeshProUGUI DialogueText, GuardText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool NextText = true;
    public AudioSource DialogueSound;
    public GameObject controller, response, text1, text2, text3;



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
            controller.SetActive(true);
            GuardText.text = "";
            DialogueAnimator.SetTrigger("Exit");
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.8f);
        response.SetActive(false);
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
