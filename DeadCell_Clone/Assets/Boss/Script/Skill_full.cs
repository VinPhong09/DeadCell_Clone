using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Skill_full : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject summonray;
    public GameObject summonraymini;
    public Transform trans;
    
    public void SummonRay()
    {
        summonraymini = Instantiate(summonray, trans.position, Quaternion.identity);   
    }
    public void DesRay()
    {
        Destroy(summonraymini); 
    }
}
