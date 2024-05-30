using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ZoomCam2 : MonoBehaviour
{
    public float detectionDistance = 2.0f;
    public GameObject UI;

    public GameObject player;
    private bool isPlayerNear = false;

    public GameObject panel;
    public float moveDistance = 100f;
    public float wipeTime = 1f;
    public float maxY = 0f;
    private Vector2 startPosition;

    public GameObject panel2;
    public float moveDistance2 = 100f;
    public float wipeTime2 = 1f;
    public float maxY2 = 0f;
    private Vector2 startPosition2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = panel.GetComponent<RectTransform>().anchoredPosition;
        startPosition2 = panel2.GetComponent<RectTransform>().anchoredPosition;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= detectionDistance)
        {
            if (!isPlayerNear)
            {
                isPlayerNear = true;
/*                UI.SetActive(false);*/
                StartCoroutine(WipePanelCoroutine());
                StartCoroutine(WipePanelCoroutine2());
            }
        }
        else
        {
            if (isPlayerNear)
            {
                isPlayerNear = false;
                StartCoroutine(ResetPanelCoroutine());
                StartCoroutine(ResetPanelCoroutine2());
            }
        }
    }
    IEnumerator WipePanelCoroutine()
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        float elapsedTime = 0f;
        while (elapsedTime < wipeTime)
        {
            float t = elapsedTime / wipeTime;
            Vector2 newPosition = new Vector2(startPosition.x, Mathf.Lerp(startPosition.y, maxY - moveDistance, t));
            panelRectTransform.anchoredPosition = newPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Vector2 finalPosition = new Vector2(startPosition.x, maxY - moveDistance);
        panelRectTransform.anchoredPosition = finalPosition;
    }
    private IEnumerator ResetPanelCoroutine()
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        float elapsedTime = 0f;
        while (elapsedTime < wipeTime)
        {
            float t = elapsedTime / wipeTime;
            Vector2 newPosition = new Vector2(startPosition.x, Mathf.Lerp(maxY - moveDistance, startPosition.y, t));
            panelRectTransform.anchoredPosition = newPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        panelRectTransform.anchoredPosition = startPosition;
    }

    IEnumerator WipePanelCoroutine2()
    {
        RectTransform panelRectTransform = panel2.GetComponent<RectTransform>();
        float elapsedTime = 0f;
        while (elapsedTime < wipeTime2)
        {
            float t = elapsedTime / wipeTime2;
            Vector2 newPosition = new Vector2(startPosition2.x, Mathf.Lerp(startPosition2.y, maxY2 - moveDistance2, t));
            panelRectTransform.anchoredPosition = newPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Vector2 finalPosition = new Vector2(startPosition2.x, maxY2 - moveDistance2);
        panelRectTransform.anchoredPosition = finalPosition;
    }
    private IEnumerator ResetPanelCoroutine2()
    {
        RectTransform panelRectTransform = panel2.GetComponent<RectTransform>();
        float elapsedTime = 0f;
        while (elapsedTime < wipeTime2)
        {
            float t = elapsedTime / wipeTime2;
            Vector2 newPosition = new Vector2(startPosition2.x, Mathf.Lerp(maxY2 - moveDistance2, startPosition2.y, t));
            panelRectTransform.anchoredPosition = newPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        panelRectTransform.anchoredPosition = startPosition2;
    }
}
