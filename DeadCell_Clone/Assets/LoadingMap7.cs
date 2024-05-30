using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class LoadingMap7 : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image progressBar;
    public Text progressText;
    public bool test = false;
    public float fillDuration = 3.0f;
    private float fillStartTime;
    public GameObject panelNextmap;
    public void loadScrenn(int sceneId)
    {
        fillStartTime = Time.time;
        test = true;
        Destroy(panelNextmap);
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
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
