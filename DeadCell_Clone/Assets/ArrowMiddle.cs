using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMiddle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Rigidbody2D rb;
    GameObject game;
    [SerializeField] public EnemyStatus enemyStatus;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game = FindObjectOfType<Boss_Flip>().gameObject;
        enemyStatus = FindObjectOfType<EnemyStatus>();
        MoveArrow();
        Flip();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatus>().TakeDamage((int)enemyStatus.GetDame());
            Destroy(this.gameObject);
        }
    }
    public void MoveArrow()
    {
        rb.velocity = new Vector2(speed*game.GetComponent<Boss_Flip>().flip,0f);
    }
    public void Flip()
    {
        if (game.GetComponent<Boss_Flip>().flip == 1)
        {
            transform.localScale *= -1;
        }
    }
}
