using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Skill_full_50 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject summonray50;
    public GameObject summonraymini50;
    public Transform trans;
    
    public void SummonRay50()
    {
        summonraymini50 = Instantiate(summonray50, trans.position, Quaternion.identity);   
        Destroy(summonraymini50,0.6f);
    }
}
