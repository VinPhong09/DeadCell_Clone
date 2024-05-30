using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom_end : MonoBehaviour
{
    public GameObject boomend;
    public GameObject summonboomend;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Create an explosion effect
           summonboomend= Instantiate(boomend, (collision.transform.position - new Vector3(0,0.33f,0)), Quaternion.identity);
           collision.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
            // Destroy the ball and player
            Destroy(this.gameObject);
            Destroy(summonboomend,1f);
        }
    }
}
