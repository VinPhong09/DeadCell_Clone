using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keycode : MonoBehaviour
{
    public Button button;
    private void Start()
    {
        button = GetComponent<Button>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            button.onClick.Invoke();
        }
    }
}
