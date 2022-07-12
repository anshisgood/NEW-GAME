using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle toggle;
    public AudioSource music;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void MuteMusic()
    {
        music.enabled = false;
    }

    public void UnmuteMusic()
    {
        music.enabled = true;
    }

    public void ToggleMusic()
    {
        if(toggle.isOn)
        {
            MuteMusic();
        }
        else
        {
            UnmuteMusic();
        }
    }
}