using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_7_Skill_3_ATK : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
            
        }
    }
}
