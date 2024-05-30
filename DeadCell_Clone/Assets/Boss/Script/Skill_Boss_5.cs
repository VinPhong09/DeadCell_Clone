using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Boss_5 : MonoBehaviour
{
    public GameObject SkillBoss;
    public GameObject BossBoss;
    public GameObject SkillBoss1;
    public GameObject BossBoss1;
    public Transform player;
    public GameObject summonL;
    public GameObject summonLL;
    public GameObject summon1;
    private void Start()
    {
        player= FindObjectOfType<PlayerStatus>().transform;
    }
    public void Skill()
    {
       BossBoss = Instantiate(SkillBoss, new Vector3(player.position.x+1,player.position.y-0.33f,0), Quaternion.identity);
       Destroy(BossBoss,2.8f);
    }
    public void Skill50()
    {
        BossBoss1 = Instantiate(SkillBoss1, new Vector3(player.position.x + 1, player.position.y-0.33f, 0), Quaternion.identity);
        Destroy(BossBoss1, 2.8f);
    }
    public void Summon()
    {
       summon1 = Instantiate(summonL,summonLL.transform.position, Quaternion.identity);
    }

}
