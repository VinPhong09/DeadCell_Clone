using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Flip_always : MonoBehaviour
{
    public GameObject player;
    public bool isFlipped = false;

    private void Start()
    {
        player = FindObjectOfType<LeafController>().gameObject; 
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > player.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x < player.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }

}
