using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Character c;
    //public float dame;
    public BossDrop bossDrop;
    //Move
    public float moveDirection;
    public float moveDirection_y;
    public float moveSpeed;
    public float jumpPower = 10f;
    public static bool disMove = false;
    //Ground Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundPlayer;
    //Jump
    bool facingRight = true;
    public bool flip = true;
    public int facing = 1;
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
    public Transform ArrowPoint;
    public GameObject Arrow ;
    public float timeDelay;
    public float timeDestroy;
    //SpecialAttack
    public bool canSpecial = false;
    public float timeDelaySp;
    [SerializeField] InforSkill skill1;
    //Air_Attack
    public bool canAirAtk = false;
    public Transform AirPoint;
    public GameObject AirAtk;
    [SerializeField] InforSkill skill2;
    //Roll
    public bool isRoll;
    public float delayRoll;
    public float m_rollCurrentTime;
    public float rollForce = 6f;
    //Idle
    public float delayIdle;
    public bool shell = false;
    public GameObject Load;
    public GameObject _UI;
    //SKill
    public float cooldown1 = 1f;
    public float timeCool1;
    public float cooldown2 = 3f;
    public float timeCool2;
    public float cooldown3 = 9f;
    public float timeCool3;
    //sound
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
    public bool canUseSkill2 = true;
    public bool hasUsedSkill2 = false;
    public float initialCooldown3 = 0f;
    public bool canUseSkill3 = true;
    public bool hasUsedSkill3 = false;
    private void Start()
    {
        cooldown2 = skill1.timeRenew;
        cooldown3 = skill2.timeRenew;
        _UI.SetActive(true);
        if (!hasUsedSkill1)
        {
            canUseSkill1 = true;
            timeCool1 = Time.timeSinceLevelLoad + initialCooldown;
            hasUsedSkill1 = true;
        }
        if (!hasUsedSkill2)
        {
            canUseSkill2 = true;
            timeCool2 = Time.timeSinceLevelLoad + initialCooldown2;
            hasUsedSkill2 = true;
        }
        
        if (!hasUsedSkill3)
        {
            canUseSkill3 = true;
            timeCool3 = Time.timeSinceLevelLoad + initialCooldown3;
            hasUsedSkill3 = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        moveDirection = Input.GetAxisRaw("Horizontal");
        moveDirection_y= Input.GetAxisRaw("Vertical");
        m_timeSinceAttack += Time.deltaTime;
        m_rollCurrentTime -= Time.deltaTime;
        if (m_rollCurrentTime < 0)
        {
            isRoll = false;
        }
        else
        {
            isRoll = true;
        }
        if (!canUseSkill2 && m_timeSinceAttack >= cooldown2 + timeCool2)
        {
            canUseSkill2 = true;
        }
        if (!canUseSkill3 && m_timeSinceAttack >= cooldown3 + timeCool3)
        {
            canUseSkill3 = true;
        }
        Jump();
        Flip();
        Attack();
        
        Roll();
        Move();
        if (c.GetComponent<PlayerStatus>().MP > 0)
        {
            SpeacialAtk();
        }
        Block();
        if (gameObject.GetComponent<PlayerStatus>().die == true)
        {
            Time.timeScale = 0f;
        }

        //Load = FindObjectOfType<NextMap>().gameObject.transform.GetChild(0).gameObject;
        
        _UI = FindObjectOfType<Ability>().gameObject;
    }
    private void OnValidate()
    {
        c = FindObjectOfType<Character>();
    }
    void Move()
    {
        if (disMove == false)
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
            //Run
            if (moveDirection != 0 && isGround)
            {
                // Reset timer
                delayIdle = 0.05f;
                if (!moveSound.isPlaying)
                {
                    moveSound.Play();
                }
                main.SetInteger("AnimState", 1);
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
    /*private void FixedUpdate()
    {
        Move();
    }*/
    public bool IsGrounded()
    {
        return isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundPlayer);
    }
    private void Flip()
    {
        if (flip)
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
    }
    private void Jump()
    {
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                doubleJump = !doubleJump;
                main.SetTrigger("Jump");
                jumpSound.PlayOneShot(jumpSound.clip);
            }
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            main.SetTrigger("Jump");
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.65f && !isRoll )
        {
            
            c.randomNum = Random.value;
            main.SetTrigger("Atk");
            attackSound.PlayOneShot(attackSound.clip);
            //DropManager.Instance.Drop(this.bossDrop.dropList,this.bossDrop.amountDropItems);
            /*main.SetTrigger("Arrow");*/
            StartCoroutine(StartAtkArrow());
        }
    }
    public void Block()
    {
        if (c.GetComponent<PlayerStatus>().MP>0)
        {
            if (Input.GetMouseButtonDown(1) && !isRoll)
            {
                
                //Need : Block not rotatie
                main.SetTrigger("Def");
                main.SetBool("IdleDef", true);
                flip = false;
                
                c.GetComponent<PlayerStatus>().openShell = true;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                disMove = true;

            }
            else if (Input.GetMouseButtonUp(1))
            {
                shell = false;
                main.SetBool("IdleDef", false);
                flip = true;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //c.GetComponent<PlayerStatus>().GetShell(shell);
                c.GetComponent<PlayerStatus>().openShell = false;
                disMove = false;
            }
        }
        
    }
    public void Roll()
    {
        if (Input.GetKeyDown("left shift") && !isRoll && isGround && moveDirection != 0 && Time.timeSinceLevelLoad - timeCool1 >= cooldown1)
        {
            isRoll = true;
            rollSound.Play();
            main.SetTrigger("Roll");
            rb.velocity = new Vector2(moveDirection * rollForce * transform.localScale.x,0f);
            //transform.position += new Vector3(moveDirection,moveDirection_y,0f) * rollForce * Time.deltaTime;
            
        }

    }
    public void SpeacialAtk()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isGround && !isRoll && canUseSkill2)
        {
            canSpecial = true;
            canUseSkill2 = false;
            FindObjectOfType<PlayerStatus>().dameSkill = c.dameTotal * skill1.bounusDame + (skill1.totalDame);
            FindObjectOfType<PlayerStatus>().MP -= skill1.MP_Out;
            
            main.SetTrigger("Sp_Atk");ESound.PlayOneShot(ESound.clip);
            timeCool2 = m_timeSinceAttack ;
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && canUseSkill3)
        {
            canAirAtk = true;
            canUseSkill3 = false;
            timeCool3 = m_timeSinceAttack;
            main.SetTrigger("Air_Atk");
            StartCoroutine(StartAttackSp());            
            FindObjectOfType<PlayerStatus>().dameSkill = c.dameTotal * skill2.bounusDame + (skill2.totalDame);
            FindObjectOfType<PlayerStatus>().MP -= skill2.MP_Out;
            
            QSound.PlayOneShot(QSound.clip);
            
        }
        
    }
    IEnumerator StartAttackSp()
    {
        yield return new WaitForSeconds(timeDelaySp);
        var spAtk = Instantiate(AirAtk, AirPoint.position, Quaternion.identity);
        Destroy(spAtk, 2f);
    }
    IEnumerator StartAtkArrow()
    {
        yield return new WaitForSeconds(timeDelay);
        var arrow = Instantiate(Arrow, ArrowPoint.position, Quaternion.identity);
        Destroy(arrow, timeDestroy);
    }
    
    
}
