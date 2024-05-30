using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_7_Skill_4_50 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FireA;
    public GameObject FireB;
    public GameObject FireC;
    public GameObject summonFireA;
    public GameObject summonFireB;
    public GameObject summonFireC;
    public GameObject transA;
    public GameObject transB;
    public GameObject transC;
    public void Fire_A()
    {
        summonFireA = Instantiate(FireA, transA.transform.position, Quaternion.identity);
        Destroy(summonFireA,0.5f);
    }
    public void Fire_B()
    {
        summonFireB = Instantiate(FireB, transB.transform.position, Quaternion.identity);
        Destroy(summonFireB, 0.5f);
    }
    public void Fire_C()
    {
        summonFireC = Instantiate(FireC, transC.transform.position, Quaternion.identity);
        Destroy(summonFireC, 0.5f);
    }
}
