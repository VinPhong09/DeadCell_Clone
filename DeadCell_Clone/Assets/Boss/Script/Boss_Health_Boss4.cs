using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health_Boss4 : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 500;
    public GameObject deathEffect;
    public bool isInvulnerable =false;
    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;
        health -= damage;
        StartCoroutine(DamageAnimation());
        if (health <= 260)
        {
            GetComponent<Animator>().SetBool("Is50%", true);
        }
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
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
