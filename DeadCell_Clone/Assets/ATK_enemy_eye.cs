using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_enemy_eye : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject arrowPoint;
    public GameObject arrow;
    public GameObject arrowHead;
    EnemyStatus c;
    void Start()
    {
        c = FindObjectOfType<EnemyStatus>();
    }

    // Update is called once per frame
    void attack()
    {
        c.randNum = Random.value;
        arrowHead= Instantiate(arrow, arrowPoint.transform.position, Quaternion.identity);
        Destroy(arrowHead, 2f);
    }
}
