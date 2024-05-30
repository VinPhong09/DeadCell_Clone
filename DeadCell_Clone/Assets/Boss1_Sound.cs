using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Sound : MonoBehaviour
{
    public AudioSource walk_boss;
    public AudioSource hit_boss;
    public AudioSource boss_50;
    public AudioSource danhxa;
    public void walk()
    {
   
            walk_boss.Play(); 
    }
    public void hit()
    {
        hit_boss.Play();
    }
}
