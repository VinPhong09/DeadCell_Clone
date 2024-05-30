using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;

public class Skill_Boss_7 : MonoBehaviour
{
    public GameObject Skill1;
    public GameObject Skill1_50;
    public GameObject Summon1;
    public GameObject Summon1_50;
    public GameObject transskill1;
    public GameObject transskill1_50;
    public Transform player;
    public GameObject Skill3;
    public GameObject Skill3_50;
    public GameObject Skill4;
    public GameObject Skill4_50;
    public GameObject Summon3_1;
    public GameObject Summon3_2;
    public GameObject Summon3_3;
    public GameObject Summon3_4;
    public GameObject Summon3_5;
    public GameObject Summon3_1_50;
    public GameObject Summon3_2_50;
    public GameObject Summon3_3_50;
    public GameObject Summon3_4_50;
    public GameObject Summon3_5_50;
    public GameObject transskill3_1;
    public GameObject transskill3_2;
    public GameObject transskill3_3;
    public GameObject transskill3_4;
    public GameObject transskill3_5;
    public GameObject Summon4;
    public GameObject Summon4_50;
    public GameObject transskill4;
    public static float playerhieght;
    public GameObject summonR;
    public GameObject summonRR;
    public GameObject summonL;
    public GameObject summonLL;
    public GameObject summon1;
    public GameObject summon2;
    void Update()
    {
        playerhieght = GetComponent<SpriteRenderer>().bounds.size.y;
        player = FindObjectOfType<PlayerStatus>().transform;
    }
    public void Summon()
    {
        summon1 = Instantiate(summonR, summonRR.transform.position, Quaternion.identity);
        summon2 = Instantiate(summonL, summonLL.transform.position, Quaternion.identity);
    }
    public void Skill_1()
    {
        Summon1 = Instantiate(Skill1, transskill1.transform.position, Quaternion.identity);
       /* Vector2 direction = (player.position - transskill1.transform.position);
        direction.Normalize();*/

        // Ð?t t?c ð? ném bóng
        Rigidbody2D BossBossRigidbody = Summon1.GetComponent<Rigidbody2D>();
        BossBossRigidbody.velocity = transform.right * 2f;

    }
    public void Skill_1_50()
    {
        Summon1_50 = Instantiate(Skill1_50, transskill1_50.transform.position, Quaternion.identity);

        Vector2 direction = (player.position - transform.position) - new Vector3(0,0.3f,0);
        direction.Normalize();

        // Ð?t t?c ð? ném bóng
        Rigidbody2D BossBossRigidbody_50 = Summon1_50.GetComponent<Rigidbody2D>();
        BossBossRigidbody_50.velocity = direction * 10;

    }
    public void Skill_3_1()
    {
        Summon3_1 = Instantiate(Skill3, transskill3_1.transform.position, Quaternion.identity);
    }
    public void Skill_3_2()
    {
        Summon3_2 = Instantiate(Skill3, transskill3_2.transform.position, Quaternion.identity);
    }
    public void Skill_3_3()
    {
        Summon3_3 = Instantiate(Skill3, transskill3_3.transform.position, Quaternion.identity);
    }
    public void Skill_3_4()
    {
        Summon3_4 = Instantiate(Skill3, transskill3_4.transform.position, Quaternion.identity);
    }
    public void Skill_3_5()
    {
        Summon3_5 = Instantiate(Skill3, transskill3_5.transform.position, Quaternion.identity);
    }
    public void DesSkill3_1()
    {
        Destroy(Summon3_1);
    }
    public void DesSkill3_2()
    {
        Destroy(Summon3_2);
    }
    public void DesSkill3_3()
    {
        Destroy(Summon3_3);
    }
    public void DesSkill3_4()
    {
        Destroy(Summon3_4);
    }
    public void DesSkill3_5()
    {
        Destroy(Summon3_5);
    }
    public void Skill_4()
    {
        Summon4 = Instantiate(Skill4, transskill4.transform.position, Quaternion.identity);
    }
    public void Skill_4_50()
    {
        Summon4_50 = Instantiate(Skill4_50, new Vector3(player.transform.position.x+0.05f, player.transform.position.y-(playerhieght-1.4f),0), Quaternion.identity);
        Destroy(Summon4_50, 2f);
    }
    public void Des_Skill_4()
    {
        Destroy(Summon4);
    }
    /*public void Des_Skill_4_50()
    {
        Destroy(Summon4_50);
    }*/
}
    // public void Summon()
    //{
    //  summon = Instantiate(summon, player.position, Quaternion.identity);
    //summon1 = Instantiate(summon1, player.position, Quaternion.identity);
    //}

