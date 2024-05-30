using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="ItemEffect/Heal")]
public class HealthItemEffect : UsableItemEffect
{
    public int HealthAmount;
    public int ManaAmount;
    public override void ExecuteEffect(UsableItem parentItem, PlayerStatus playerStatus)
    {
        if (playerStatus.canUseHP)
        {
            playerStatus.HP += HealthAmount;
        }
        if (playerStatus.canUseMP)
        {
            playerStatus.MP += ManaAmount;
        }
        
        
    }
    public override string GetStat()
    {
        return "Heals for" + HealthAmount + " HP and " + ManaAmount + " MP.";
    }
}
