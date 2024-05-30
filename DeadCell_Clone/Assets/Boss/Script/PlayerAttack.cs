using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Character c;
    public float time;
    public float startTime;
    public Animator anim;
    public PolygonCollider2D coll2D;
    public GameObject enemy;
    public int num=1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        c = FindObjectOfType<Character>();
        Attack();
    }
    public void Attack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Atk"+ WindCharController.m_currentAttack))
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
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStatus>().TakeDamage(c.GetDame() - collision.gameObject.GetComponent<EnemyStatus>().def*(1-c.ArP.Value/50));
            //Destroy(this.gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            //Destroy(this.gameObject);
            collision.gameObject.GetComponent<BossStatus>().TakeDamage(c.GetDame() - collision.gameObject.GetComponent<BossStatus>().def * (1 - c.ArP.Value / 50));
            //Destroy(this.gameObject);
        }
    }
}
