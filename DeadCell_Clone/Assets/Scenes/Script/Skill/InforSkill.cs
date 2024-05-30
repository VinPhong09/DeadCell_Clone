using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Skill")]
public class InforSkill : ScriptableObject
{
    public Sprite sprite;
    public string skillName;
    public int curLevel;
    public int maxLevel ;
    public int MP_Out;
    public int price;
    public float baseDame;
    public float bounusDame;
    public float totalDame;
    public float timeRenew;
    
    public bool CanUpgrade()
    {
        if (curLevel < maxLevel)
        {
            return true;
        }
        else
        {
            curLevel = maxLevel;
            return false;
        }
    }
    public float setTotalDame()
    {
        return totalDame = baseDame*(1f + (0.05f * curLevel));
    }
}
