using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Enemy_Bomb : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public bool chase = false;
    public Animator animator;
    public Vector2 start;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        start = this.transform.position;
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
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - 0.5f * player.GetComponent<PlayerStatus>().facing, player.transform.position.y - 1f), speed * Time.deltaTime);
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
