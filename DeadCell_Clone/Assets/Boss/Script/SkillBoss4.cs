using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBoss4 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SkillBoss;
    public GameObject BossBoss;
    public GameObject SkillBoss1;
    public GameObject BossBoss1;
    public Transform player;
    public GameObject summonLL;
    public GameObject summonL;
    public GameObject summon3;

    private void Update()
    {
        player = FindObjectOfType<PlayerStatus>().transform;
    }
    public void Skill()
    {
        BossBoss = Instantiate(SkillBoss, player.position, Quaternion.identity);
        Destroy(BossBoss, 1f);
    }
    public void Skill50()
    {
        BossBoss1 = Instantiate(SkillBoss1, player.position, Quaternion.identity);
        Destroy(BossBoss1, 1f);
    }
    public void Summon()
    {
      
        summon3 =Instantiate(summonLL,summonL.transform.position,Quaternion.identity);
    }
    
    
}
