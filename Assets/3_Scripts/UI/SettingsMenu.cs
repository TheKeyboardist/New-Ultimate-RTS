using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioVol;
    public void SetVolume(float volume)
    {
        audioVol.SetFloat("Volume",volume);
        Debug.Log(volume);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
