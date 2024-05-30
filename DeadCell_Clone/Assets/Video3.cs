using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Video3 : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject panel;
    public GameObject panel1;
    public GameObject panel2;

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            panel.SetActive(true);
            panel1.SetActive(false);
            panel2.SetActive(false);
        }
    }
}
