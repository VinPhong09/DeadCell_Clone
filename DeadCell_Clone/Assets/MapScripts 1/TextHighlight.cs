using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class TextHighlight : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject panel;
    public string[] dialogueLines;
    public AudioSource textSound;
    public AudioClip yourSoundFile;
    public AudioSource buttonSound;
    public GameObject UI;

    private bool playerInRange;
    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool isEndOfLine = false;
    private bool isDialogueDisplayed = false;
    private bool checkPanel = false;

    private void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UI.SetActive(false);
            panel.SetActive(true);
            checkPanel = true;
            playerInRange = true;
            dialogueText.gameObject.SetActive(true);
            StartCoroutine(TypeDialogue());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            playerInRange = false;
            panel.SetActive(false);
            checkPanel = false;
            dialogueText.gameObject.SetActive(false);
            StartCoroutine(UIp());
        }
    }
    IEnumerator UIp()
    {
        if (!checkPanel)
        {
            yield return new WaitForSeconds(0.2f);
            UI.SetActive(true);
        }
    }
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.N) && panel.activeSelf)
            {
                buttonSound.Play();
                if (!isTyping)
                {
                    currentLineIndex++;
                    if (currentLineIndex >= dialogueLines.Length)
                    {
                        dialogueText.gameObject.SetActive(false);
                        panel.SetActive(false);
                        currentLineIndex = 0;
                        return;
                    }
                    StartCoroutine(TypeDialogue());
                }
                else if (isTyping && !isEndOfLine)
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[currentLineIndex];
                    isEndOfLine = true;
                }
                else if (isTyping && isEndOfLine)
                {
                    currentLineIndex++;
                    if (currentLineIndex >= dialogueLines.Length)
                    {
                        dialogueText.gameObject.SetActive(false);
                        panel.SetActive(false);
                        currentLineIndex = 0;
                        return;
                    }
                    StartCoroutine(TypeDialogue());
                }
            }
        }
    }

    IEnumerator TypeDialogue()
    {
        isTyping = true;
        isEndOfLine = false;
        isDialogueDisplayed = true;
        dialogueText.text = "";
        float soundTime = 0f;
        foreach (char c in dialogueLines[currentLineIndex])
        {
            dialogueText.text += c;
            textSound.PlayOneShot(yourSoundFile);
            soundTime = yourSoundFile.length;
            yield return new WaitForSeconds(0.02f);
            yield return new WaitForSeconds(soundTime / 10);
        }
        isTyping = false;
        isEndOfLine = true;
        isDialogueDisplayed = false;
    }
}
