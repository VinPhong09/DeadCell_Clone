using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefGate : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Rigidbody2D rb;
    private GameObject player;
    public bool chase = false;
    public Animator animator;
    public float attackRange;
    public GameObject start;
    public float attackTimer;
    public float attackDelay;
    public float distance;
    EnemyStatus c;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        c= GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (chase == true)
        {
            Chase();
            Flip();
        }
        else
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            ReturnStartPoint();
            FlipReturn();
            NotMove();
        }

    }
    private void Chase()
    {

        if (Vector2.Distance(player.transform.position, rb.position) > distance)
        {
            Vector2 target = new Vector2(player.transform.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            animator.SetBool("isRunning", true);
        }
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y-0.6f), speed * Time.deltaTime);
        if (Vector2.Distance(player.transform.position, rb.position) <= attackRange)
        {
            if (attackTimer <= 0f)
            {
                c.randNum = Random.value;
                animator.SetBool("ATK", true);
                attackTimer = attackDelay;
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }
        }
        else
        {
            animator.SetBool("ATK", false);
        }
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
          //  animator.SetBool("ATK", false);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //animator.SetBool("ATK", false);
        }
    }
    private void FlipReturn()
    {
        if (transform.position.x >= start.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("ATK", false);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("ATK", false);
        }
    }
    private void NotMove()
    {
        if (transform.position.x == start.transform.position.x)
        {
            animator.SetBool("isRunning", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void ReturnStartPoint()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = Vector2.MoveTowards(transform.position, start.transform.position, speed * Time.deltaTime);
    }
}
