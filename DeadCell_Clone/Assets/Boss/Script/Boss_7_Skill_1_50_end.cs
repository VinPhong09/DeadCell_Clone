using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_7_Skill_1_50_end : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skill1_50_end;
    public GameObject summonskill1_50_end;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Create an explosion effect
            summonskill1_50_end = Instantiate(skill1_50_end, (collision.transform.position - new Vector3(0,Skill_Boss_7.playerhieght-1.8f, 0)), Quaternion.identity);

            // Destroy the ball and player
            Destroy(this.gameObject);
            Destroy(summonskill1_50_end, 1.5f);
        }
    }
}
