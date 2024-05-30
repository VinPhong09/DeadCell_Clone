using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_effects_point2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Skill_Effect1;
    public GameObject Skill_Effect_point1;
    public GameObject Skill_Effect_point1_1;
    public void Skill_Point1()
    {
        Skill_Effect_point1 = Instantiate(Skill_Effect1, Skill_Effect_point1_1.transform.position, Quaternion.identity);
    }
}
