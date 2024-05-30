using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D doorCollider;
    public Animator doorAnimator;
    public bool canOpen;
    public bool doorOpened = false;
    private bool animationPlayed = false;
    public GameObject canhCong;
    

    void Start()
    {
        // L?y Collider c?a Door
        doorCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !doorOpened && !animationPlayed && canOpen)
        {
            canOpen = !canOpen;
            doorCollider.isTrigger = true;
            doorAnimator.SetTrigger("Open");
            doorOpened = true;
            animationPlayed = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckCollision(other.gameObject, true);
    }

    private void OnTriggerExit(Collider other)
    {
        CheckCollision(other.gameObject, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision.gameObject, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckCollision(collision.gameObject, false);
    }

    private void CheckCollision(GameObject gameObject, bool state)
    {
        if (gameObject.CompareTag("Player") && canhCong == null)
        {
            canOpen = true;
        }
    }
}
