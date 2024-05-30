using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_spwan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skill_spawn_1;
    public GameObject skill_spawn_2;
    public GameObject skill_spawn_3;
    public GameObject skill_spawn_1_1;
    public GameObject skill_spawn_2_1;
    public GameObject skill_spawn_3_1;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public void SpawnSkill()
    {
        skill_spawn_1_1 = Instantiate(skill_spawn_1, point1.transform.position, Quaternion.identity);
    }
}
