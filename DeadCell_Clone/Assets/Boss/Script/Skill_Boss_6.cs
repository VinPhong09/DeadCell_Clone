using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Boss_6 : MonoBehaviour
{
    public GameObject SkillBoss;
    public GameObject BossBoss;
    public Transform player;
    private float speed = 25f;
    public float scale;
    public GameObject SkillBoss1;
    public GameObject SkillBoss2;
    public GameObject SkillBoss3;
    public GameObject SkillBoss4;
    public GameObject SkillBoss2_50_1;
    public GameObject SkillBoss2_50_2;
    public GameObject SkillBoss2_50_3;
    public GameObject SkillBoss1_50;
    public GameObject BossBoss2;
    public GameObject BossBoss1_50;
    public GameObject BossBoss2_50_1;
    public GameObject BossBoss2_50_2;
    public GameObject BossBoss2_50_3;
    public GameObject BossBoss3;
    public GameObject BossBoss1;
    public GameObject BossBoss4;
    public GameObject child;
    public GameObject child2;
    public GameObject child3;
    public GameObject child3_50;
    public GameObject child4;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject child1_50;
    public GameObject SkillBoss3_50;
    public GameObject BossBoss3_50;
    public GameObject SummonR;
    public GameObject SummonRR;
    public GameObject Summon1;
    private void Update()
    {
        player = FindObjectOfType<PlayerStatus>().transform;
    }
    public void Summon()
    {
        Summon1 = Instantiate(SummonR, SummonRR.transform.position, Quaternion.identity);
    }
    public void Skill()
    {
        BossBoss = Instantiate(SkillBoss, this.transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position) - new Vector3(0,0.1f,0);
        direction.Normalize();

        // Ð?t t?c ð? ném bóng
        Rigidbody2D BossBossRigidbody = BossBoss.GetComponent<Rigidbody2D>();
        BossBossRigidbody.velocity = direction * speed;
        
    }
    public void Skill1()
    {
        BossBoss1=Instantiate(SkillBoss1,child.transform.position, Quaternion.identity);
        BossBoss2=Instantiate(SkillBoss2, child2.transform.position, Quaternion.identity);
        BossBoss3 = Instantiate(SkillBoss3, child3.transform.position, Quaternion.identity);
        Destroy(BossBoss1, 2f);
        Destroy(BossBoss2, 2.5f);
        Destroy(BossBoss3, 3f);
    }
    public void Skill1_50()
    {
        BossBoss1_50 = (Instantiate(SkillBoss1_50,child1_50.transform.position, Quaternion.identity));
        Destroy(BossBoss1_50, 2.5f);
    }
    public void Skill2()
    {
        BossBoss4 = Instantiate(SkillBoss4, child4.transform.position, Quaternion.identity);
    }
    public void DesSkill2()
    {
        Destroy(BossBoss4);
    }
    public void Skill2_50()
    {
        BossBoss2_50_1= Instantiate(SkillBoss2_50_1,tree1.transform.position, Quaternion.identity);
        BossBoss2_50_2= Instantiate(SkillBoss2_50_2,tree2.transform.position, Quaternion.identity);
        BossBoss2_50_3= Instantiate(SkillBoss2_50_3,tree3.transform.position, Quaternion.identity);
        Destroy(BossBoss2_50_1, 1f);
        Destroy(BossBoss2_50_2, 1f);
        Destroy(BossBoss2_50_3, 1f);
    }
    public void Skill3_50()
    {
        BossBoss3_50=Instantiate(SkillBoss3_50, child3_50.transform.position, Quaternion.identity);
    }
    public void DesSkill3_50()
    {
        Destroy(BossBoss3_50);
    }
  
    }


