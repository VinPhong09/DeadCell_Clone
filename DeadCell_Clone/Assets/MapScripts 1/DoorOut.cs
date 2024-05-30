using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DoorOut : MonoBehaviour
{
    public Collider2D doorCollider;
    public Animator doorAnimator;
    public GameObject boss;

    void Start()
    {
        // L?y Collider c?a Door
        doorCollider = GetComponent<Collider2D>();
    }
    void Update()
    {
        
        if (boss == null && Input.GetKeyDown(KeyCode.F))
        {
            doorCollider.isTrigger = true;
            doorAnimator.SetTrigger("Open");

        }
        else
        {
            // Layer "Boss" t?n t?i
            // Không làm gì c?
        }
    }

}
