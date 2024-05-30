using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ChaseControl : MonoBehaviour
{
    public Fly_Enemy[] enemyFlyArray;
    public Fly_Enemy_Bomb[] bombArray;
    public DefGate[] gateArray;
    public DefGate_Right[] rightArray;
    EnemyStatus c;
    // Start is called before the first frame update
    private void Start()
    {
        c=GetComponent<EnemyStatus>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
        {
            foreach (Fly_Enemy enemy in enemyFlyArray)
            {
                enemy.chase = true;
            }
            foreach (Fly_Enemy_Bomb bomb in bombArray)
            {
                //c.randNum = Random.value;
                bomb.chase = true;
            }
            foreach (DefGate gate in gateArray)
            {
                gate.chase = true;
            }
            foreach(DefGate_Right right in rightArray)
            {
                right.chase = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Fly_Enemy enemy in enemyFlyArray)
            {
                enemy.chase = false;
            }
            foreach (Fly_Enemy_Bomb bomb in bombArray)
            {
                bomb.chase = false;
            }
            foreach (DefGate gate in gateArray)
            {
                gate.chase = false;
            }
            foreach (DefGate_Right right in rightArray)
            {
                right.chase = false;
            }
        }
    }
}
