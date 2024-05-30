using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1_50 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BossBoss1_50;
    public GameObject SkillBoss1_50;
    public GameObject trans;
    public void Skill1_50_1()
    {
        BossBoss1_50 =Instantiate(SkillBoss1_50, trans.transform.position, Quaternion.identity);
        Destroy(BossBoss1_50, 0.8f);
    }
}
