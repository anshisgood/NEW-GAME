using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public Button play;
    public Button options;
    public Button quit;
    public GameObject panel2;
    public Image happyEmoji;
    public Image scaredEmoji;
    public Image angryEmoji;
    public AudioSource happyMusic;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RUSure()
    {
        panel.SetActive(true);
        happyEmoji.enabled = false;
        scaredEmoji.enabled = true;
        play.enabled = false;
        options.enabled = false;
        quit.enabled = false;

        happyMusic.enabled = false;
    }
    public void RUSureExit()
    {
        panel.SetActive(false);
        happyEmoji.enabled = true;
        scaredEmoji.enabled = false;
        play.enabled = true;
        options.enabled = true;
        quit.enabled = true;

        happyMusic.enabled = true;
    }
    public void QuitGame()
    {
        panel2.SetActive(true);
        panel.SetActive(false);

        happyEmoji.enabled = false;
        scaredEmoji.enabled = false;
        angryEmoji.enabled = true;


        Application.Quit();
    }
}
