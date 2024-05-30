using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource die;
    void dead()
    {
        die.Play();
    }
}
