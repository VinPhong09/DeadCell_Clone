using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4_Skill_ATK : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamagexa = 20;
    public Vector2 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public void Attack()
    {
        /*Vector3 pos = transform.TransformPoint(attackOffset);
        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            //cloInfor.GetComponent<PlayerStatus>().TakeDamage(attackDamagexa);
            //player.GetComponent<PlayerStatus>().TakeDamage(attackDamagexa);
            Debug.Log(2);
        }*/
        Vector3 pos = transform.position;
        pos += transform.forward* attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D cloInfor = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (cloInfor != null)
        {
            cloInfor.GetComponent<PlayerStatus>().TakeDamage((int)this.gameObject.GetComponent<BossStatus>().GetDame());
        }
       
    }
}
