using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Flip : MonoBehaviour
{
    public GameObject player;
    public bool isFlipped = false;
    public int flip;
    private void Start()
    {
        player = FindObjectOfType<PlayerStatus>().gameObject;
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x>player.transform.position.x && isFlipped)
        {
            flip = -1;
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x<player.transform.position.x && !isFlipped)
        {
            flip = 1;
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
