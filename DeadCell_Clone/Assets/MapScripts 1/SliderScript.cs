using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public AudioSource[] audioSources;
    public Slider soundSlider;

    void Start()
    {
        soundSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    void ChangeVolume()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = soundSlider.value;
        }
    }
}
