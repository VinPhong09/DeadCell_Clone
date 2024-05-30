using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fly_Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bomb;
    public GameObject bombb;
    public GameObject player;
    EnemyStatus c;
    void Start()
    {
        player = FindObjectOfType<PlayerStatus>().gameObject;
        c = GetComponent<EnemyStatus>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            c.randNum = Random.value;
            Debug.Log(c.randNum);
            bombb = Instantiate(bomb, new Vector2(player.transform.position.x, player.transform.position.y - 0.5f), Quaternion.identity);
            // c.randNum = Random.value;
            collision.GetComponent<PlayerStatus>().TakeTrueDame((int)c.GetDame());
            Destroy(bombb, 0.5f);
            Destroy(bomb);
            Destroy(this.gameObject);
            //  bombb =Instantiate(bomb,new Vector2(player.transform.position.x,player.transform.position.y-0.5f), Quaternion.identity);
            /*collision.GetComponent<PlayerStatus>().TakeTrueDame((int)c.GetDame());*/
        }
    }
}

