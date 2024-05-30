using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Boss_6_50 : MonoBehaviour
{
    public GameObject SkillBoss;
    public GameObject BossBoss;
    public Transform player;
    private float speed = 7f;
    public float scale;
    public GameObject SkillBoss1_50;
    public GameObject SkillBoss2_50;
    public GameObject SkillBoss3_50;
    public GameObject BossBoss2_50;
    public GameObject BossBoss3_50;
    public GameObject BossBoss1_50;
    public GameObject child3_50;

    public void Skill()
    {
        BossBoss = Instantiate(SkillBoss, this.transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position) - new Vector3(0,0.33f,0);
        direction.Normalize();

        // Ð?t t?c ð? ném bóng
        Rigidbody2D BossBossRigidbody = BossBoss.GetComponent<Rigidbody2D>();
        BossBossRigidbody.velocity = direction * speed;
        
    }
/*    public void Skill1()
    {
        BossBoss1=Instantiate(SkillBoss1,child.transform.position, Quaternion.identity);
        BossBoss2=Instantiate(SkillBoss2, child2.transform.position, Quaternion.identity);
        BossBoss3 = Instantiate(SkillBoss3, child3.transform.position, Quaternion.identity);
        Destroy(BossBoss1, 2f);
        Destroy(BossBoss2, 2.5f);
        Destroy(BossBoss3, 3f);
    }
    public void Skill2()
    {
        BossBoss4 = Instantiate(SkillBoss4, child4.transform.position, Quaternion.identity);
    }*/
    public void Skill3_50()
    {
        BossBoss3_50 = Instantiate(SkillBoss3_50, child3_50.transform.position, Quaternion.identity);
    }
 /*   public void DesSkill2()
    {
        Destroy(BossBoss4);
    }*/
    public void DesSkill3_50()
    {
        Destroy(BossBoss3_50);
    }
    }
    // public void Summon()
    //{
    //  summon = Instantiate(summon, player.position, Quaternion.identity);
    //summon1 = Instantiate(summon1, player.position, Quaternion.identity);
    //}

