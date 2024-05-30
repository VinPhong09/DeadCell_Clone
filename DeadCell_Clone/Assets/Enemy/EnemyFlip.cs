using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    // Start is called before the first frame update
    Boss_Flip enemy;
    void Start()
    {
        enemy = GetComponent<Boss_Flip>();
        enemy.LookAtPlayer();
    }

    void Update()
    {
        enemy.LookAtPlayer();
    }
}
