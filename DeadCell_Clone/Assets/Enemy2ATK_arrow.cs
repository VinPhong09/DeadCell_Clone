using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2ATK_arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy2ATK arrow;
    public GameObject ArrowEnemy;
    public Transform ArrowPoint;
    EnemyStatus c;
    void Start()
    {
        arrow = FindObjectOfType<Enemy2ATK>();
        c = FindObjectOfType<EnemyStatus>();
    }

    // Update is called once per frame
    void attack()
    {
        
        c.randNum = Random.value;
        GameObject ArrowIns = Instantiate(ArrowEnemy,ArrowPoint.transform.position, Quaternion.identity);
        ArrowIns.GetComponent<Rigidbody2D>().AddForce(arrow.Direction *  arrow.Force);
        Destroy(ArrowIns,0.8f);
    }
}
