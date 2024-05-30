using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] public EnemyStatus enemyStatus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyStatus = FindObjectOfType<EnemyStatus>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerStatus>().TakeDamage((int)enemyStatus.GetDame());
        Destroy(gameObject);
    }

}
