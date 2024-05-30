using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClick1 : MonoBehaviour
{
    public Button Button;
    private void Awake()
    {
        Button = GetComponent<Button>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
