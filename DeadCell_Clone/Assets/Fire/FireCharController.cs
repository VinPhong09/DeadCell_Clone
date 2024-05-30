using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireCharController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    [SerializeField] Character c;
    public float dame;
    //Move
    public float moveDirection;
    public float moveSpeed;
    public float jumpPower = 10f;
    public static bool disMove = false;
    //Ground Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] public LayerMask groundPlayer;
    //Jump
    public int facing = 1;
    bool facingRight = true;
    bool doubleJump;
    public bool isGround;
    //Dash
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    //Animation
    public Animator main;
    //Attack
    public float m_timeSinceAttack;
    public static int m_currentAttack = 0;
    //SpecialAttack
    public bool canSpecial = false;
    [SerializeField] InforSkill skill1;
    //Air_Attack
    public bool canAirAtk = false;
    [SerializeField] InforSkill skill2;
    //Roll
    public bool isRoll = false;
    public float m_rollDuration = 8.0f / 14.0f;
    public float m_rollCurrentTime;
    public float rollForce = 6f;
    //Idle
    public float delayIdle;
    public GameObject Load;
    public GameObject _UI;
    //SKill
    public float cooldown1 = 1f;
    public float timeCool1;
    public float cooldown2 = 3f;
    public float timeCool2;
    public float cooldown3 = 9f;
    public float timeCool3;
    public float timeSkillUse;
    //Block
    public bool shell;
    //sound
    public AudioSource jumpSound;
    public AudioSource moveSound;
    public AudioSource rollSound;
    public AudioSource attackSound;
    public AudioSource QSound;
    public AudioSource ESound;

    public float initialCooldown = 0f;
    private bool canUseSkill1 = true;
    private bool hasUsedSkill1 = false;
    public float initialCooldown2 = 0f;
    private bool canUseSkill2 = true;
    private bool hasUsedSkill2 = false;
    public float initialCooldown3 = 0f;
    private bool canUseSkill3 = true;
    private bool hasUsedSkill3 = false;


    void Start()
    {
        c = GetComponent<Character>();
        cooldown2 = skill1.timeRenew;
        cooldown3 = skill2.timeRenew;
        _UI.SetActive(true);
        if (!hasUsedSkill1)
        {
            canUseSkill1 = true;
            timeCool1 = timeSkillUse + initialCooldown;
            hasUsedSkill1 = true;
        }
        
        if (!hasUsedSkill2)
        {
            canUseSkill2 = true;
            timeCool2 = timeSkillUse + initialCooldown2;
            hasUsedSkill2 = true;
        }
        
        if (!hasUsedSkill3)
        {
            canUseSkill3 = true;
            timeCool3 = timeSkillUse + initialCooldown3;
            hasUsedSkill3 = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!disMove)
        {
            moveDirection = Input.GetAxisRaw("Horizontal");
        }

        m_timeSinceAttack += Time.deltaTime;
        timeSkillUse += Time.deltaTime;
        if (isRoll)
            m_rollCurrentTime += Time.deltaTime;
        if (m_rollCurrentTime > m_rollDuration)
            isRoll = false;

        Jump();
        Flip();
        Attack();
        Block();
        Roll();
        
        if (!disMove)
        {
            Move();
        }
        if (c.GetComponent<PlayerStatus>().MP > 0)
        {
            SpeacialAtk();
        }
        if (gameObject.GetComponent<PlayerStatus>().die == true)
        {
            Time.timeScale = 0f;
        }

        Load = FindObjectOfType<NextMap>().gameObject.transform.GetChild(0).gameObject;
        Load = FindObjectOfType<Panel>().gameObject;
        _UI = FindObjectOfType<Ability>().gameObject;
        //Physics2D.IgnoreLayerCollision(7, 6, true);
    }
    public bool IsGrounded()
    {
        return isGround = Physics2D.OverlapCircle(groundCheck.position, 0.25f, groundPlayer);
        //return isGround = Physics2D.IsTouchingLayers(groundPlayer);
    }
    void Move()
    {
        if (!disMove)
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
            //Run
            if (moveDirection != 0 && isGround)
            {
                // Reset timer
                delayIdle = 0.05f;
                main.SetInteger("AnimState", 1);
                if (!moveSound.isPlaying)
                {
                    moveSound.Play();
                }

            }
            //Idle
            else
            {
                // Prevents flickering transitions to idle
                delayIdle -= Time.deltaTime;

                if (delayIdle < 0)
                {
                    main.SetInteger("AnimState", 0);
                    if (moveSound.isPlaying)
                    {
                        moveSound.Stop();
                    }
                }
            }
        }



    }
    private void Flip()
    {
        if (facingRight && moveDirection < 0f || !facingRight && moveDirection > 0f)
        {
            facingRight = !facingRight;
            facing *= -1;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void Jump()
    {
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                doubleJump = !doubleJump;
                main.SetTrigger("Jump");
                jumpSound.PlayOneShot(jumpSound.clip);
            }

        }
        if ((Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.UpArrow)) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            main.SetTrigger("Jump");
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.5f && !isRoll)
        {
            c.randomNum = Random.value;
            m_currentAttack++;

            // Loop back to one after third attack
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (m_timeSinceAttack > 1.0f)
                m_currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            main.Play("Atk" + m_currentAttack);
            attackSound.PlayOneShot(attackSound.clip);
            // Reset timer
            m_timeSinceAttack = 0.0f;
        }
    }
    public void Block()
    {
        if (c.GetComponent<PlayerStatus>().MP > 0)
        {
            if (Input.GetMouseButtonDown(1) && !isRoll)
            {
                shell = true;
                main.SetTrigger("Def");
                main.SetBool("IdleDef", true);
                c.GetComponent<PlayerStatus>().openShell = true;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                disMove = true;

            }

            else if (Input.GetMouseButtonUp(1))
            {
                shell = false;
                main.SetBool("IdleDef", false);
                c.GetComponent<PlayerStatus>().openShell = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                disMove = false;
            }
        }

    }
    public void Roll()
    {
        if (Input.GetKeyDown("left shift") && !isRoll && isGround && moveDirection != 0 && timeSkillUse - timeCool1 >= cooldown1)
        {
            isRoll = true;

            main.SetTrigger("Roll");
            rb.velocity = new Vector2(moveDirection * rollForce, rb.velocity.y);
            
            rollSound.Play();
        }
        
    }
    public void SpeacialAtk()
    {
        if (Input.GetKeyDown(KeyCode.E) && isGround && !isRoll && canUseSkill2)
        {
            canSpecial = true;
            main.SetTrigger("Sp_Atk");
            canUseSkill2 = false;
            //rb.position = new Vector2(rb.position.x + 0.1f*facing,rb.position.y);
            FindObjectOfType<PlayerStatus>().dameSkill = c.dameTotal * skill1.bounusDame + (skill1.totalDame);
            FindObjectOfType<PlayerStatus>().MP -= skill1.MP_Out;
            timeCool2 = timeSkillUse;
            ESound.PlayOneShot(ESound.clip);
        }
        if (!canUseSkill2 && timeSkillUse - timeCool2 >= cooldown2)
        {
            canUseSkill2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Q) && canUseSkill3)
        {
            canAirAtk = true;
            main.SetTrigger("Air_Atk");
            canUseSkill3 = false;
            FindObjectOfType<PlayerStatus>().dameSkill = c.dameTotal * skill2.bounusDame + (skill2.totalDame);
            FindObjectOfType<PlayerStatus>().MP -= skill2.MP_Out;
            timeCool3 = timeSkillUse;
            QSound.PlayOneShot(QSound.clip);
        }
        if (!canUseSkill3 && timeSkillUse - timeCool3 >= cooldown3)
        {
            canUseSkill3 = true;
        }
    }
    
}
