using System.Collections;                   //작업자 : 김영호
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioOption : MonoBehaviour
{
    public static AudioOption AO;
    public AudioMixer masterMixer;
    public Slider masterV, bgmV, sfxV;
    private void Start()
    {
        masterV.value = PlayerPrefs.GetFloat("Master", 0f);
        bgmV.value = PlayerPrefs.GetFloat("BGM", 0f);
        sfxV.value = PlayerPrefs.GetFloat("SFX", 0f);
    }

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

        PlayerPrefs.SetFloat("Master", masterV.value);
        PlayerPrefs.SetFloat("BGM", bgmV.value);
        PlayerPrefs.SetFloat("SFX", sfxV.value);
    }
}
