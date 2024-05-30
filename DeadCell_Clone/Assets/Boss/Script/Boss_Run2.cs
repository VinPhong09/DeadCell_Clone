using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run2 : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 2f;
    public float attackRange = 0.6f;
    public float attackRangefar = 1.2f;
    public float distance = 0.6f;
    Boss_Flip boss;
    BossStatus c;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player= GameObject.FindGameObjectWithTag("Player").transform;
       rb= animator.GetComponent<Rigidbody2D>();
       boss = animator.GetComponent<Boss_Flip>();
       c = animator.GetComponent<BossStatus>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        if (Vector2.Distance(player.position, rb.position) > distance)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {   
            c.randomNum = Random.value;
            animator.SetTrigger("ATK");
        }
        else if (Vector2.Distance(player.position, rb.position) <= attackRangefar)
        {
            c.randomNum = Random.value;
            animator.SetTrigger("ATK1");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("ATK");
        animator.ResetTrigger("ATK1");
    }

   
}
