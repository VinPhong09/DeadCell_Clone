using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using TMPro;


public class NPCText : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Image[] images;
    public GameObject panel;
    public string[] dialogueLines;
    public AudioSource textSound;
    public AudioClip yourSoundFile;
    public AudioSource buttonSound;

    private bool playerInRange;
    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool isEndOfLine = false;
    private bool isDialogueDisplayed = false;
    private bool isImage1Active = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
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
            dialogueText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.N)&& panel.activeSelf)
        {
            buttonSound.Play();
            if (!isTyping)
            {
                currentLineIndex++;
                if (currentLineIndex >= dialogueLines.Length)
                {
                    dialogueText.gameObject.SetActive(false);
                    panel.SetActive(false); // T?t panel khi ?ã ch?y h?t text
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
                    panel.SetActive(false); // T?t panel khi ?ã ch?y h?t text
                    currentLineIndex = 0;
                    return;
                }
                StartCoroutine(TypeDialogue());
            }
        }
    }

    IEnumerator TypeDialogue()
    {
        if (isImage1Active)
        {
            images[0].gameObject.SetActive(false);
            images[1].gameObject.SetActive(true);
            isImage1Active = false;
        }
        else
        {
            images[0].gameObject.SetActive(true);
            images[1].gameObject.SetActive(false);
            isImage1Active = true;
        }
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
