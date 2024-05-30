using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject explosionPrefab2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Create an explosion effect
            
            explosionPrefab2 = Instantiate(explosionPrefab, (collision.transform.position - new Vector3(0,0.66f,0)), Quaternion.identity);
            collision.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
            // Destroy the ball and player
            Destroy(this.gameObject);
            Destroy(explosionPrefab2,3.5f);
        }
    }
}
