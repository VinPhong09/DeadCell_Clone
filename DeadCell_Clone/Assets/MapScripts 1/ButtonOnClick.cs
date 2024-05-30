using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour
{
    public Button Button;
    public KeyCode keyCode;
    private void Awake()
    {
        Button = GetComponent<Button>();
    }
    void Update()
    {
        if (Input.GetKeyDown(keyCode) && Button.interactable)
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
