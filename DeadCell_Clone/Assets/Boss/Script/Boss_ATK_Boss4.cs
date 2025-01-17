using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ATK_Boss4 : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamage = 20;
    public int attackDamage50 = 40;
    public Vector3 attackOffset;
    public float attackRange = 1f;
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
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
        }
    }

}