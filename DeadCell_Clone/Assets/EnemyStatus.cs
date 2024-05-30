using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float HP;
    public float dame;
    public float def;
    public float critRate;
    public float randNum;
    public bool die;
    public float delayRaise;
    public BossDrop bossDrop;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        StartCoroutine(DamageAnimation());
        if (HP <= 0)
        {
            Die();
        }

    }
    public float GetDame()
    {
        randNum = Random.value;
        if (critRate >= randNum)
        {
            return dame * 2f;
        }
        else return dame;
    }
    public void Die()
    {
        Destroy(this.gameObject);
        this.GetComponent<DropManager>().Drop(this.bossDrop.dropList, this.bossDrop.amountDropItems);
    }
    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}
