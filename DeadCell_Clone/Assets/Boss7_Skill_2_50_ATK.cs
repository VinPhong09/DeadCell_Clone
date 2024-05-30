using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss7_Skill_2_50_ATK : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
            Destroy(this.gameObject,2f);
        }
    }
}
