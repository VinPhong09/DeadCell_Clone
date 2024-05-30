using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject player;
    public bool chase = false;
    public Animator animator;
    public float attackTimer = 0f;
    public float attackDelay = 3f;
    public Vector2 start;
    EnemyStatus c;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        start = this.transform.position;
        c=GetComponent<EnemyStatus>();
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
        }
        
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2 (player.transform.position.x -0.7f*player.GetComponent<PlayerStatus>().facing,player.transform.position.y -0.7f), speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.transform.position) <1f)
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
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void FlipReturn()
    {
        if (transform.position.x >= start.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void ReturnStartPoint() 
    { 
        transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.position = Vector2.MoveTowards(transform.position, start, speed * Time.deltaTime);    
    }
}
