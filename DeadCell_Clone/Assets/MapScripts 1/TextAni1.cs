using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAni1 : MonoBehaviour
{
    public float blinkInterval = 0.5f;
    public TMPro.TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            tmp.text = "Loading.";
            yield return new WaitForSeconds(0.2f);

            tmp.text = "Loading..";
            yield return new WaitForSeconds(0.2f);

            tmp.text = "Loading...";
            yield return new WaitForSeconds(0.2f);

            tmp.text = "Loading....";
            yield return new WaitForSeconds(0.2f);

            tmp.text = "Loading.....";
            yield return new WaitForSeconds(0.2f);
        }
    }
}

