using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAni2 : MonoBehaviour
{
    public TMP_Text textComponent;
    public float wipeSpeed = 1f;

    private string originalText;
    private string currentText;

    private void Start()
    {
        originalText = textComponent.text;
        currentText = "";
        textComponent.text = currentText;
    }

    private void Update()
    {
        if (currentText != originalText)
        {
            currentText = originalText.Substring(0, Mathf.RoundToInt(Time.time * wipeSpeed));
            textComponent.text = currentText;
        }
    }
}
