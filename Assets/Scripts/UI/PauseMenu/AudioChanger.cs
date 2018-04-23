using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioChanger : MonoBehaviour {

    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private Image soundImage;
    [SerializeField]
    private Sprite image1;
    [SerializeField]
    private Sprite image2;

    // Use this for initialization
    void Start () {
        float sound;
        mixer.GetFloat("MasterVolume", out sound);
        if (sound == 0f)
        {
            soundImage.sprite = image1;
        }
        else
        {
            soundImage.sprite = image2;
        }
    }

    public void Change()
    {
        float sound;
        mixer.GetFloat("MasterVolume", out sound);
        if(sound == 0f)
        {
            SetMusicVolumeOff();
            soundImage.sprite = image2;
        }
        else
        {
            SetMusicVolumeOn();
            soundImage.sprite = image1;
        }
    }

    private void SetMusicVolumeOn()
    {
        mixer.SetFloat("MasterVolume", 0f);
    }

    private void SetMusicVolumeOff()
    {
        mixer.SetFloat("MasterVolume", -80f);
    }
}
