using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class LoadingMap : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image progressBar;
    public Text progressText;
    public bool test = false;
    public float fillDuration = 3.0f;
    private float fillStartTime;
    public GameObject panelNextmap;
    public GameObject panelUI;

    private void Start()
    {
        panelUI = FindObjectOfType<Canvas>().gameObject;
    }
    private void Update()
    {
        if (panelNextmap == null)
        {
            Time.timeScale = 1;
            Debug.Log(1);
        }

    }
    public void loadScrenn(int sceneId)
    {
        Destroy(panelNextmap);
        fillStartTime = Time.time;
        test = true;
        
        StartCoroutine(loadingScreen(sceneId));
    }
    IEnumerator loadingScreen(int sceneId)
    {
        
        LoadingScreen.SetActive(true);
        while (Time.time - fillStartTime <= fillDuration)
        {
            float progress = (Time.time - fillStartTime) / fillDuration;
            progressBar.fillAmount = progress;
            progressText.text = (int)(progress * 100f) + "%";
            yield return null;
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);


        while (!operation.isDone && operation.allowSceneActivation)
        {
            if (operation.progress >= 0.9f)
            {
                panelUI.SetActive(true);
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
        operation.allowSceneActivation = false;
    }
}
