using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    //private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider backgroundSlider;
    private float backgroundFloat;
    //public Slider soundEffectsSlider;
    //private float soundEffectsFloat;
    public AudioSource backgroundAudio;
    //public AudioSource[] soundEffectsAudio;

    private void Start()
    {
        SetVolumeLevel(1);

        //PlayerPrefs allows you to save values through scenes
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {
            backgroundFloat = .05f;
            backgroundSlider.value = backgroundFloat;
            //soundEffectsFloat = .75f;
            //soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            //PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            //soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            //soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SetVolumeLevel (float sliderValue)
    {
        mixer.SetFloat ( "MusicVol", Mathf.Log10 (sliderValue) * 20 );
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        //PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        /*for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }*/
    }
}
