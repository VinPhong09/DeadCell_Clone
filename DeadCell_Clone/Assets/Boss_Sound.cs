using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sound : MonoBehaviour
{
    public AudioSource walk_boss;
    public AudioSource hit_boss;
    public AudioSource boss_50;
    public AudioSource danhxa;
    public AudioSource atkcombo;
    public void walk()
    {
   
            walk_boss.Play(); 
    }
    public void hit()
    {
        hit_boss.Play();
    }
    public void boss()
    {
        boss_50.Play();
    }
    public void danhxaboss()
    {
        danhxa.Play();
    }
    public void atk()
    {
        atkcombo.Play();
    }
}
