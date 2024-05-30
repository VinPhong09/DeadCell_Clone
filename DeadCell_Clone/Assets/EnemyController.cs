using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public EnemyStatus[] enemyStatus;
    private void Update()
    {
        for (int i = 0; i < enemyStatus.Length; i++)
        {
            if (enemyStatus[i].HP <= 0)
            {
                enemyStatus[i].Die();
                enemyStatus[i].die = true;
                StartCoroutine(Raise(enemyStatus[i]));
            }
        }
    }
    IEnumerator Raise(EnemyStatus enemyStatus)
    {
        enemyStatus.HP = 100;
        yield return new WaitForSeconds(enemyStatus.delayRaise);
        enemyStatus.die = false;
        enemyStatus.gameObject.SetActive(true);
        
        
    }

}
