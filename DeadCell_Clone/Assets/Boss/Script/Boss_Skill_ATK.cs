using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Skill_ATK : MonoBehaviour
{
    // Start is called before the first frame update


    public float time;
    public float startTime;
    public Animator anim;
    public PolygonCollider2D coll2D;
    public CharController controller;
    public GameObject enemy;
    public int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ATK" + controller.m_currentAttack))
        {
            StartCoroutine(StartAttack());
        }
        //Physics2D.IgnoreLayerCollision(transform.gameObject.layer,6,true);
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        coll2D.enabled = true;
        StartCoroutine(disableHitBox());
    }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

    }
}
