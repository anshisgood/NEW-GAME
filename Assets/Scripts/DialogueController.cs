using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{

    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool NextText = true;
    public GameObject grandmaDialogue, player, defaultIcon, ammunitionDisplay, grandmaDialogueCam;



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
                    NextText = false;

                }

            }
        }


    }

    void NextSentence()
    {
        if(Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            DialogueText.text = "";
            DialogueAnimator.SetTrigger("Exit");
            Index = 0;
            StartDialogue = true;
            StartCoroutine(wait());
            
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        grandmaDialogue.SetActive(false);
        grandmaDialogueCam.SetActive(false);
        player.SetActive(true);
        defaultIcon.SetActive(true);
        ammunitionDisplay.SetActive(true);
    }
    
    IEnumerator WriteSentence()
    {
        foreach(char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        Index++;
        NextText = true;
    }
}
