using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLeftToRight : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    GameObject game;
    public float timeDestroy = 10f;
    [SerializeField] public EnemyStatus enemyStatus;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemyStatus = FindObjectOfType<EnemyStatus>();

        MoveArrow();

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
        rb.velocity = new Vector2(speed, 0f);
        Destroy(this.gameObject, 3f);
    }
}
