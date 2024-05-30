using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_Run4 : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 2f;
    public float attackRange = 0.8f;
    public float attackRangefar = 3f;
    public float distance = 0.8f;
    public float attackTimer = 0f;
    public float attackDelay = 3f;
    public GameObject SkillBoss;
    public GameObject BossBoss;
    Boss_Flip boss;
    BossStatus c;
    //private Animation Skill_Animation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss_Flip>();
        c = animator.GetComponent<BossStatus>();
        //Animation Skill_Animation = GameObject.Find("Skill_Boss").GetComponent<Animation>();
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
        if (Vector2.Distance(player.position, rb.position) <= attackRangefar)
        {
            if (attackTimer <= 0f) // N?u ð? ð?m ngý?c ð? th?i gian
            {
                c.randomNum = Random.value;
                animator.SetTrigger("ATK1");
                attackTimer = attackDelay; // Ð?t l?i th?i gian ð?m ngý?c              
            }
            else
            {
                attackTimer -= Time.deltaTime; // Gi?m th?i gian ð?m ngý?c
            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("ATK");
        animator.ResetTrigger("ATK1");
    }
}