using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoint;
    [SerializeField] Animator animator;
    public float moveSpeed;
    public int patrolDestination;
    public PlayerStatus playerStatus;
    public float attackRange;
    public bool saw;
    Vector3 curScale;
    public bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        curScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        SawPlayer();
        animator.SetBool("isRunning", true);

        //CheckPatrolMove();
    }
    public void Patrol()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[0].position) < 1f)
            {

                patrolDestination = 1;
            }
        }
        else if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[1].position) < 1f)
            {
                patrolDestination = 0;
            }
        }
    }
    public void CheckPatrolMove()
    {
        if (patrolDestination == 0)
        {
            Quaternion newRotate = new Quaternion(0f, 0f, 0f, 0f);
            transform.localRotation = newRotate;
            transform.localScale = new Vector3(-1 * curScale.x, curScale.y, curScale.z);
        }
        else
        {
            Quaternion newRotate = new Quaternion(0f, 0f, 0f, 0f);
            transform.localRotation = newRotate;
            this.transform.localScale = curScale;

        }
    }
    public void SawPlayer()
    {
        if (Vector2.Distance(playerStatus.transform.position, this.transform.position) <= attackRange)
        {
            saw = true;
        }
        if (playerStatus.transform.position.x < patrolPoint[0].position.x || playerStatus.transform.position.x > patrolPoint[1].position.x)
        {
            saw = false;
        }
        
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;
        if (transform.position.x > playerStatus.gameObject.transform.position.x)
        {

            //transform.localScale = flipped;
            transform.localScale = curScale;
            Quaternion newRotate = new Quaternion(0f, 180f, 0f, 0f);
            transform.localRotation = newRotate;
            // transform.localScale = new Vector3(-1 * curScale.x, curScale.y, curScale.z);
            isFlipped = false;
        }
        else if (transform.position.x < playerStatus.gameObject.transform.position.x)
        {

            transform.localScale = curScale;
            Quaternion newRotate = new Quaternion(0f, 0f, 0f, 0f);
            transform.localRotation = newRotate;
            isFlipped = true;
        }
        
    }

}




