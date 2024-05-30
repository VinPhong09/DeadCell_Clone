using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATKWalkAround : MonoBehaviour
{
    // Start is called before the first frame update
    public float pushForce = 10f; // L?c ð?y
    public AudioSource bombb;
    EnemyStatus c;
    private void Start()
    {
        c = GetComponent<EnemyStatus>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                c.randNum = Random.value;
                playerRb.GetComponent<PlayerStatus>().TakeTrueDame((int)c.GetDame());
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                bombb.Play();
                Destroy(this.gameObject);
            }
        }
    }
}
