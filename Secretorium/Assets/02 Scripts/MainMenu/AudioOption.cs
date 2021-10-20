using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioOption : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider masterV, bgmV, sfxV;

    private void Update()
    {
        AudioControl(masterV.value, "Master");
        AudioControl(bgmV.value, "BGM");
        AudioControl(sfxV.value, "SFX");
    }

    public void AudioControl(float sound, string Parameter)
    {

        if (sound == -20f) masterMixer.SetFloat(Parameter, -80);
        else masterMixer.SetFloat(Parameter, sound);
    }
}
