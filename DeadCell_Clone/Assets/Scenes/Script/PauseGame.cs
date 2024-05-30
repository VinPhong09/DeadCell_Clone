using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject bookPanel;
    public bool isPaused = false;
    public bool isPanelActive = false;

    void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (bookPanel.activeSelf)
        {
            isPanelActive = true;
            isPaused = true;
            //Time.timeScale = 0f;
        }
        else
        {
            isPanelActive = false;
            isPaused = false;
            Time.timeScale = 1f;
        }
    }

}
