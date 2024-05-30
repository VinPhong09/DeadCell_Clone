using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonN : MonoBehaviour
{
    public Button button;
    public AudioSource buttonSound;

    private void Start()
    {
        button = GetComponent<Button>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            OnButtonClick();
        }
    }

    public void OnButtonClick()
    {
        buttonSound.Play();
    }
}
