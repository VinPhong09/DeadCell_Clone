using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    //Move
    public float moveDirection;
    public float moveSpeed;
    public float jumpPower = 10f;
    //Ground Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundPlayer;
   //Jump
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
    private int m_currentAttack = 0;
    //SpecialAttack
    public bool canSpecial = true;
    //Roll
    public bool isRoll = false;
    public float m_rollDuration = 8.0f / 14.0f;
    public float m_rollCurrentTime;
    public float rollForce = 6f;
    //Idle
    public float delayIdle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        m_timeSinceAttack += Time.deltaTime;
        if (isRoll)
            m_rollCurrentTime += Time.deltaTime;
        if (m_rollCurrentTime > m_rollDuration)
            isRoll = false;
        Jump();
        Flip();
        Attack();
        Block();
        Roll();
        Move();
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        //Run
        if(moveDirection !=0 && isGround )
        {
            // Reset timer
            delayIdle = 0.05f;
            main.SetInteger("AnimState", 1);
        }
        //Idle
        else
        {
            // Prevents flickering transitions to idle
            delayIdle -= Time.deltaTime;
            if (delayIdle < 0)
                main.SetInteger("AnimState", 0);
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
        if (facingRight && moveDirection < 0f || !facingRight && moveDirection > 0f)
        {
            facingRight = !facingRight;
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
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                doubleJump = !doubleJump;
                main.SetTrigger("Jump");
            }
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            main.SetTrigger("Jump");
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.25f && !isRoll )
        {
            m_currentAttack++;

            // Loop back to one after third attack
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (m_timeSinceAttack > 1.0f)
                m_currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            main.SetTrigger("Attack" + m_currentAttack);

            // Reset timer
            m_timeSinceAttack = 0.0f;
        }
    }
    public void Block()
    {
        if (Input.GetMouseButtonDown(1) && !isRoll )
        {
            main.SetTrigger("Block");
            main.SetBool("IdleBlock", true);
        }

        else if (Input.GetMouseButtonUp(1))
        {
            main.SetBool("IdleBlock", false);
        }
    }
    public void Roll()
    {
        if(Input.GetKeyDown("left shift") && !isRoll && isGround && moveDirection != 0)
        {
            isRoll = true;
            main.SetTrigger("Roll");
            rb.velocity = new Vector2(moveDirection*rollForce, rb.velocity.y);
        }
    }
}
