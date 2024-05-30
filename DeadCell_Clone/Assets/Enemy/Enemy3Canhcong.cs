using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Canhcong : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;
    public float speedEnemy;
    private Animator animatorenemy;
    public float attackRange;
    void Start()
    {
        playerPos=player.GetComponent<Transform>(); 
        currentPos=GetComponent<Transform>().position;
        animatorenemy=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < distance && Vector2.Distance(transform.position, playerPos.position) >= attackRange )
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speedEnemy*Time.deltaTime);
            animatorenemy.SetBool("IsRun", true);
            animatorenemy.SetBool("IsRunback", false);
            if (Vector2.Distance(transform.position, playerPos.position) <= attackRange )
            {
                animatorenemy.SetBool("IsAtk", true);
            }
        }
        else
        {
            
            if (Vector2.Distance(transform.position, currentPos) <= 0)
            {
                animatorenemy.SetBool("IsRun", false);
                animatorenemy.SetBool("IsAtk", false);
            }
            else
            {
                transform.position=Vector2.MoveTowards(transform.position,currentPos,speedEnemy*Time.deltaTime);         
                animatorenemy.SetBool("IsRunback", true);
                animatorenemy.SetBool("IsAtk", false);
                //animatorenemy.SetBool("IsRun", true);
            }
        }
    }
}
