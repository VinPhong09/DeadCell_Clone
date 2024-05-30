using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ATK_Boss_7 : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamagegan = 40;
    public int attackDamagegan_50 = 40;
    public int attackDameskill3 = 10;
    public float attackRange;
    public float attackRange1;
    public Vector3 attackOffset;
    public Vector3 attackOffset1;
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
    public void Attack_50()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+50);
        }
    }
    public void Attack_skill_3()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+100);
        }
    }
    public void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, attackRange1);
    }
}
