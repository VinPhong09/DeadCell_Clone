using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireA_ATK : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
            
        }
    }
}
