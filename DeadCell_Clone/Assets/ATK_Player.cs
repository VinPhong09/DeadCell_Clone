using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Vector3 attackOffset;
    public Vector3 attackOffset1;
    public Vector3 attackOffset2;  
    public Vector3 attackOffset3;
    public Vector3 attackOffset4;
    public float attackRange = 1f;
    public float attackRange1 = 1f;
    public float attackRange2 = 1f;
    public float attackRange3 = 1f;
    public float attackRange4 = 1f;
    public LayerMask attackMask;
    EnemyStatus c;
    BossStatus b;
    private void Update()
    {
        c = FindObjectOfType<EnemyStatus>();
        b = FindObjectOfType<BossStatus>();
    }
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            c.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
            b.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
        }
    }
    public void Attack1()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange1, attackMask);
        if (cloInfor != null)
        {
            c.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
            b.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
        }
    }
    public void Attack2()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset2.x;
        pos += transform.up * attackOffset2.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange2, attackMask);
        if (cloInfor != null)
        {
            c.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
            b.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
        }
    }
    public void AttackAir()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset3.x;
        pos += transform.up * attackOffset3.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange3, attackMask);
        if (cloInfor != null)
        {
            c.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
            b.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
        }
    }
    public void AttackSp()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset4.x;
        pos += transform.up * attackOffset4.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange4, attackMask);
        if (cloInfor != null)
        {
            c.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
            b.TakeDamage((int)this.gameObject.GetComponent<Character>().GetDame());
        }
    }
    public void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset4.x;
        pos += transform.up * attackOffset4.y;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, attackRange4);
    }
}
