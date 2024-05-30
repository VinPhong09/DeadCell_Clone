using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemyAtk : StateMachineBehaviour
{
    [SerializeField] GameObject player;
    Rigidbody2D rb;
    public bool sawPlayer;
    public bool atk;
    public float attackRange = 0.8f;
    public float distance = 0.8f;
    EnemyStatus c;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerStatus>().gameObject;
        rb = animator.GetComponent<Rigidbody2D>();
        c= animator.GetComponent<EnemyStatus>();
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if (rb.GetComponent<EnemyPatrol>().saw)
        {
            if (Vector2.Distance(rb.transform.position,player.transform.position) <= attackRange)
            {
                atk = true;
                rb.velocity = new Vector2(0, 0);
                c.randNum = Random.value;
                animator.SetTrigger("ATK");
            }
            else
            {
                Vector2 target = new Vector2(player.transform.position.x, rb.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, rb.GetComponent<EnemyPatrol>().moveSpeed * Time.deltaTime);
                rb.MovePosition(newPos);
            }
            
        }
        else
        {
            atk = false;
            rb.GetComponent<EnemyPatrol>().Patrol();
            rb.GetComponent<EnemyPatrol>().CheckPatrolMove();
            //rb.velocity = new Vector2(rb.GetComponent<PatrolEnemy>().moveSpeed,0);
        }
        SawPlayer();
        /*if (atk)
        {
            rb.GetComponent<Boss_Flip>().LookAtPlayer();
        }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.ResetTrigger("ATK");
    }
    public void SawPlayer()
    {
        if (rb.GetComponent<EnemyPatrol>().saw)
        {
            rb.GetComponent<EnemyPatrol>().LookAtPlayer();
            if (Vector2.Distance(player.transform.position, rb.position) > distance)
            {
                Vector2 target = new Vector2(player.transform.position.x, rb.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, rb.GetComponent<EnemyPatrol>().moveSpeed * Time.deltaTime);
                rb.MovePosition(newPos);
            }
        }

    }

}