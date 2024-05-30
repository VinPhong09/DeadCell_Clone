using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_Run6 : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 2f;
    public float attackRange = 0.5f;
    public float attackRangefar = 1f;
    public float attackSkill4 = 3f;
    public float attackRange_skill3 = 0.4f;
    public float distance = 0.4f;
    public float timeatk2 = 0f;
    public float timedelay2 = 5f;
    public float timeatk3 = 0f;
    public float timedelay3 = 2f;
    public float timeatk4 = 0f;
    public float timedelay4 = 5f;
    /*public GameObject SkillBoss;
    public GameObject BossBoss;*/
    Boss_Flip boss;
    BossStatus c;
    //private Animation Skill_Animation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss_Flip>();
        c= animator.GetComponent<BossStatus>();
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
        if (Vector2.Distance(player.position, rb.position) > attackRange && (Vector2.Distance(player.position, rb.position) < distance ))
        {
            c.randomNum = Random.value;
            animator.SetTrigger("ATK1");
        }

        if (Vector2.Distance(player.position, rb.position) >= attackRangefar)
        {
            if (timeatk2 <= 0f) // N?u ð? ð?m ngý?c ð? th?i gian
            {
                c.randomNum = Random.value;
                animator.SetTrigger("ATK2");
                timeatk2 = timedelay2; // Ð?t l?i th?i gian ð?m ngý?c              
            }
            else
            {
                timeatk2 -= Time.deltaTime; // Gi?m th?i gian ð?m ngý?c
            }

        }
        if (Vector2.Distance(player.position, rb.position) >= attackRange_skill3)
        {
            if (timeatk3 <= 0f) // N?u ð? ð?m ngý?c ð? th?i gian
            {
                c.randomNum = Random.value;
                animator.SetTrigger("ATK3");
                timeatk3 = timedelay3; // Ð?t l?i th?i gian ð?m ngý?c              
            }
            else
            {
                timeatk3 -= Time.deltaTime; // Gi?m th?i gian ð?m ngý?c
            }
        }
        if ((Vector2.Distance(player.position,rb.position)) <= attackSkill4 && (Vector2.Distance(player.position, rb.position)) > distance)
        {
            c.randomNum = Random.value;
            animator.SetTrigger("ATK4");
            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("ATK1");
        animator.ResetTrigger("ATK2");
        animator.ResetTrigger("ATK3");
        animator.ResetTrigger("ATK4");
    }
}