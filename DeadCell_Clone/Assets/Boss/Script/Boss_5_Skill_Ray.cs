using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_5_Skill_Ray : MonoBehaviour
{
    public int attackDamagexa = 40;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public void Attack()
    {
        Vector3 pos = transform.position;
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage(attackDamagexa);
        }
    }
}
