using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2ATKMiddle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrowPoint;
    public GameObject arrow;
    public GameObject player;
    private Transform playerpos;
    private Vector2 currenPoint;
    public float distance;
    public  float timebetween;
    public float starttimebetween;
    public Animator animator;
    void Start()
    {
        player = FindObjectOfType<PlayerStatus>().gameObject;
        playerpos = player.GetComponent<Transform>();
        currenPoint = GetComponent<Transform>().position;
        timebetween = starttimebetween;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (timebetween <= 0 && !this.GetComponent<EnemyStatus>().die)
        {
            if (Vector2.Distance(transform.position, playerpos.transform.position) <= distance)
            {
                animator.SetBool("ATK", true);
               // Instantiate(arrow, arrowPoint.transform.position, Quaternion.identity);
                timebetween = starttimebetween;
            }
            else
            {
                animator.SetBool("ATK", false);
            }
        }
        else
        {
            timebetween -= Time.deltaTime;
        }
    }
    
}
