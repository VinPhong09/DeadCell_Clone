using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafWeapon : MonoBehaviour
{
    public Rigidbody2D rb;
    public LeafController player;
    public int facing;
    public float moveDirection;
    public float moveSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<LeafController>();
        facing = player.facing;
        ArrowShot();
    }
    // Update is called once per frame  
    void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal"); 
    }
    void ArrowShot()
    {
        if (player.flip)
        {
            
            rb.transform.localScale *= facing;
            
        }
        rb.velocity = new Vector2(moveSpeed * facing, 0);   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStatus>().TakeDamage(player.GetComponent<Character>().GetDame() -collision.gameObject.GetComponent<EnemyStatus>().def * (1 - player.GetComponent<Character>().ArP.Value / 50));
           Destroy(this.gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<BossStatus>().TakeDamage(player.GetComponent<Character>().GetDame() - collision.gameObject.GetComponent<BossStatus>().def * (1 - player.GetComponent<Character>().ArP.Value / 50));
            Destroy(this.gameObject);
        }
    }
}
