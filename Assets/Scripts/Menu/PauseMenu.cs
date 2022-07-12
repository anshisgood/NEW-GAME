using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject MoveCam, PlayerCam, PlayerMovement;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Button backButton;
    public Slider volume;
    public Toggle mute;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                //nothing
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
        MoveCam.GetComponent<MoveCamera>().enabled = true;
        PlayerCam.GetComponent<PlayerCam>().enabled = true;
        PlayerMovement.GetComponent<PlayerMovement>().enabled = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        MoveCam.GetComponent<MoveCamera>().enabled = false;
        PlayerCam.GetComponent<PlayerCam>().enabled = false;
        PlayerMovement.GetComponent<PlayerMovement>().enabled = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PleaseDontLeave()
    {
        backButton.enabled = false;
        volume.enabled = false;
        mute.enabled = false;
    }

    public void Stay()
    {
        backButton.enabled = true;
        volume.enabled = true;
        mute.enabled = true;
    }

}