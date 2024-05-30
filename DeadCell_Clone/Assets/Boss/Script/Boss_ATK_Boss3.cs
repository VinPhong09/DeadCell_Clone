using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ATK_Boss3 : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamage = 20;
    public int attackDamagexa = 25;
    public int attackDamage50 = 40;
    public int attackDamagexa50 = 50;
    public Vector3 attackOffset;
    public Vector3 attackOffset1;
    public float attackRange = 1f;
    public float attackRangexa = 1f;
    public LayerMask attackMask;
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
        }
    }
    public void Attack50()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+30);
        }
    }
    public void Attackxa()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;

        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRangexa, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+50);
        }
    }
    public void Attackxa50()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;

        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRangexa, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+70);
        }
    }
    public void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, attackRangexa);
    }
}