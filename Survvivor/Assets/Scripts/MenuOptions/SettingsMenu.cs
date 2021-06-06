using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    private AudioMixer audioMixer;

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("music", volume);
    }

    public void SetVolumeEffect(float volume)
    {
        audioMixer.SetFloat("effect", volume);
    }

    public void SetOnOffMusic(float volume)
    {
        if (volume == 1)
        {
            audioMixer.SetFloat("music", 0);
        }
        else
        {
            audioMixer.SetFloat("music", -80);
        }
    }

    public void SetOnOffEffect(float volume)
    {
        if (volume == 1)
        {
            audioMixer.SetFloat("effect", 0);
        }
        else
        {
            audioMixer.SetFloat("effect", -80);
        }
    }
}
