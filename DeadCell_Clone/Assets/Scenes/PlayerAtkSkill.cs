using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkSkill : MonoBehaviour
{
    [SerializeField] Character c;
    public float time;
    public float startTime;
    public Animator anim;
    public PolygonCollider2D coll2D;
    public GameObject enemy;
    public int num = 1;
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStatus>().TakeDamage(c.GetComponent<PlayerStatus>().dameSkill - collision.gameObject.GetComponent<EnemyStatus>().def * (1 - c.ArP.Value / 50));
            //Destroy(this.gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            //Destroy(this.gameObject);
            collision.gameObject.GetComponent<BossStatus>().TakeDamage(c.GetComponent<PlayerStatus>().dameSkill - collision.gameObject.GetComponent<BossStatus>().def * (1 - c.ArP.Value / 50));
            //Destroy(this.gameObject);
        }
    }
}
