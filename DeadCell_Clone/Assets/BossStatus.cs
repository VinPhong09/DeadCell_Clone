using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuanVo.CharacterStat;

public class BossStatus : MonoBehaviour
{
    public float heal;
    public float originHeal;
    public float dame;
    public float def;
    public float randomNum;
    public float dameTotal = 0;

    [Header("Stats")]
    public CharacterStat HP;
    public CharacterStat MP;
    public CharacterStat DA;
    public CharacterStat DEF;
    public CharacterStat ArP;
    public CharacterStat LUK;
    /*-----------------------*/
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    public GameObject bossDrop;
    public Transform dropPosition;
    // Start is called before the first frame update
    private void OnValidate()
    {
        GetHP();
        GetDef();
        GetDame();
    }
    private void Start()
    {
        originHeal = heal;
    }

    public void GetHP()
    {
        this.heal = (int)HP.Value * 100;
    }
    public void GetDef()
    {
        this.def = (int)DEF.Value * 10;
    }
    public float GetDame()
    {

        if (randomNum > (LUK.Value / 100))
        {
            //Normal dame
            return dameTotal = (DA.Value * 20);
        }
        else
        {
            //Crit dame
            return dameTotal = (DA.Value * 20) * 2;
        }
    }
    public void TakeDamage(float damage)
    {

        heal -= damage;
        StartCoroutine(DamageAnimation());

        if (heal <= (originHeal / 2))
        {
            GetComponent<Animator>().SetBool("Is50%", true);
        }
        if (isInvulnerable)
            return;
    }
    void Die()
    {
        Instantiate(bossDrop, dropPosition.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        //DropManager.Instance.Drop(this.bossDrop.dropList, this.bossDrop.amountDropItems);
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
    // Update is called once per frame
    void Update()
    {
        dameTotal = GetDame();
        if (heal <= 0)
        {

            Die();
        }
    }
}
