using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ATK_Boss_5 : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamagegan1 = 40;
    public int attackDamagegan1_50 = 40;
    public int attackDamagecombo = 40;
    public Vector3 attackOffset1;
    public Vector3 attackOffsetcombo1;
    public Vector3 attackOffsetcombo2;
    public float attackRange = 1f;
    public float attackRange1 = 1f;
    public float attackRange2 = 1f;
    public LayerMask attackMask;
    public void Attack1()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
        }
    }
    public void Attack1_50()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+50);
        }
    }
    public void Attack1combo()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset1.x;
        pos += transform.up * attackOffset1.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+50);
        }
    }
    public void Attack2combo()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffsetcombo1.x;
        pos += transform.up * attackOffsetcombo1.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange1, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+70);
        }
    }
    public void Attack3combo()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffsetcombo2.x;
        pos += transform.up * attackOffsetcombo2.y;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange2, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame()+90);
        }
    }
}
